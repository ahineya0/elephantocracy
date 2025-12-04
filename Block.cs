using System;

namespace Core
{
    public class Block
    {
        public bool IsWalkable { get; private set; }      
        public bool IsShootThrough { get; private set; } 
        public int Health { get; private set; }          


        public Block(bool isWalkable, bool isShootThrough, int health)
        {
            IsWalkable = isWalkable;
            IsShootThrough = isShootThrough;
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            if (Health > 0)
            {
                Health -= damage;

                if (IsDestroyed()) 
                {
                    Console.WriteLine("Блок разрушен");
                }
            }
        }
        public bool IsDestroyed()
        {
            return Health <= 0;
        }
        public void PrintStatus()
        {
            string status = IsDestroyed() ? "Разрушен" : $"Здоровье: {Health}";
            Console.WriteLine($"Статус блока - Доступен: {IsWalkable}, Простреливаемый: {IsShootThrough}, {status}");
        }
    }
}
