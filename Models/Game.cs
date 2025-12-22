using elephantocracy.Enums;
using elephantocracy.Interfaces;
using elephantocracy.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Models
{
    public class Game : ISerializableModel
    {
        public string GetFileName() => "game";


        private readonly Map _map;
        private InputController _inputController;

        public List<IMapObject> Objects { get; set; }

        public Game(Map map, InputController inputController)
        {
            _map = map;
            _inputController = inputController;
            Objects = new List<IMapObject>();  
        }

        public void Update()
        {
            HandleMovement();
            HandleShooting();
            UpdateBubbles();
            Cleanup();
        }

        private void HandleMovement()
        {
            foreach (var obj in Objects)
            {
                Direction? dir = null;

                if (obj is Elephant)
                    dir = _inputController.MoveDirection;
                else if (obj is Enemy enemy && enemy.Brain != null)
                    dir = enemy.Brain.MoveDirection;

                if (dir.HasValue && obj is IMove movable)
                {
                    var (newX, newY) = GetNextPosition(obj.X, obj.Y, dir.Value);
                    if (_map.IsWalkable(newX, newY))
                        movable.Move(dir.Value);
                }
            }
        }

        private (int x, int y) GetNextPosition(int x, int y, Direction dir)
        {
            return dir switch
            {
                Direction.Up => (x, y - 1),
                Direction.Down => (x, y + 1),
                Direction.Left => (x - 1, y),
                Direction.Right => (x + 1, y),
                _ => (x, y)
            };
        }

        private void HandleShooting()
        {
            foreach (var attacker in Objects.OfType<IAttack>().ToList())
            {
                bool wantsToFire = false;

                if (attacker is Elephant)
                    wantsToFire = _inputController.FirePressed;
                else if (attacker is Enemy enemy && enemy.Brain != null)
                    wantsToFire = enemy.Brain.FirePressed;

                if (wantsToFire)
                {
                    var fireResult = attacker.Fire();
                    if (fireResult.HasValue)
                    {
                        SpawnBubble(fireResult.Value);
                    }
                }
            }

            _inputController.Reset();
        }

        private void SpawnBubble(FireResult fire)
        {
            var bubble = new Bubble(fire.X, fire.Y, fire.Direction);
            Objects.Add(bubble);
        }

        private void UpdateBubbles()
        {
            foreach (var bubble in Objects.OfType<Bubble>())
            {
                bubble.Move(bubble.Direction);
                HandleBubbleCollision(bubble);
            }
        }

        private void HandleBubbleCollision(Bubble bubble)
        {
            if (!_map.InBounds(bubble.X, bubble.Y))
            {
                bubble.Destroy();
                return;
            }

            var block = _map.GetBlock(bubble.X, bubble.Y);
            if (block != null && !block.IsShootThrough)
            {
                if (block.IsDestructible)
                    block.TakeDamage(1);

                bubble.Destroy();
                return;
            }

            foreach (var enemy in Objects.OfType<Enemy>())
            {
                if (enemy.X == bubble.X && enemy.Y == bubble.Y)
                {
                    enemy.TakeDamage(1);
                    bubble.Destroy();
                    return;
                }
            }
        }

        private void Cleanup()
        {
            var deadObjects = Objects
                .OfType<Bubble>()
                .Where(b => !b.IsAlive)
                .ToList();

            foreach (var obj in deadObjects)
                Objects.Remove(obj);
        }

        public void SetInputController(InputController input)
        {
            _inputController = input;
        }
    }
}
