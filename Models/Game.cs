using elephantocracy.Interfaces;
using elephantocracy.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Models
{
    public class Game
    {
        private readonly Map _map;
        private readonly InputController _inputController;

        private readonly List<IMapObject> _mapObjects;
        private readonly List<IMove> _movables;
        private readonly List<IRotate> _rotatables;
        private readonly List<IAttack> _attackers;
        private readonly List<IEffectTarget> _effectTargets;

        public Game(Map map, InputController inputController)
        {
            _map = map;
            _inputController = inputController;
            IEnumerable<IMapObject> objects = map.GetObjects();

            _mapObjects = objects.ToList();
            _movables = objects.OfType<IMove>().ToList();
            _rotatables = objects.OfType<IRotate>().ToList();
            _attackers = objects.OfType<IAttack>().ToList();
            _effectTargets = objects.OfType<IEffectTarget>().ToList();
        }

        public void Update()
        {
            // Движение
            var dir = _inputController.MoveDirection;
            if (dir.HasValue)
            {
                foreach (var movable in _movables)
                    movable.Move(dir.Value);
            }

            // Стрельба
            if (_inputController.FirePressed)
            {
                foreach (var attacker in _attackers)
                {
                    var fireResult = attacker.Fire();
                    if (fireResult.HasValue)
                        SpawnBubble(fireResult.Value);
                }

                _inputController.Reset();
            }

            // Для пузырей
            foreach (var bubble in _mapObjects.OfType<Bubble>())
            {
                bubble.Move(bubble.Direction);
            }
        }

        private void SpawnBubble(FireResult fire)
        {
            var bubble = new Bubble(fire.X, fire.Y, fire.Direction);

            _map.AddMapObject(bubble);

            _mapObjects.Add(bubble);
            _movables.Add(bubble);
        }
    }
}
