namespace elephantocracy.Models
{
    public class Block
    {
        public bool IsWalkable { get; private set; }
        public bool IsShootThrough { get; private set; }
        public int Health { get; private set; }
        public bool IsDestructible { get; private set; } 


        public Block(bool isWalkable, bool isShootThrough, int health = 0, bool isDestructible = false)
        {
            IsWalkable = isWalkable;
            IsShootThrough = isShootThrough;
            Health = health;
            IsDestructible = isDestructible;
        }
        public void TakeDamage(int damage)
        {
            if (IsDestructible && Health > 0)
                Health -= damage;
        }
        public bool IsDestroyed()
        {
            return (IsDestructible && Health <= 0);
        }
    }
}
