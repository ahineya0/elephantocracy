using elephantocracy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Models
{
    public class Map
    {
        private int width;
        private int height;

        private Block[,] blocks;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;

            blocks = new Block[width, height];
        }

        public int Width => width;
        public int Height => height;

        public Block GetBlock(int x, int y)
        {
            if (InBounds(x, y))
                return blocks[x, y];
            return null;
        }

        public bool InBounds(int x, int y)
        {
            return x >= 0 && x < width &&
                   y >= 0 && y < height;
        }

        public bool IsWalkable(int x, int y)
        {
            if (!InBounds(x, y))
                return false;

            Block block = blocks[x, y];
            return block == null || block.IsWalkable;
        }

        public bool IsShootThrough(int x, int y)
        {
            if (!InBounds(x, y))
                return false;

            Block block = blocks[x, y];
            return block == null || block.IsShootThrough;
        }

        public void DestroyBlock(int x, int y)
        {
            if (!InBounds(x, y)) return;

            if (blocks[x, y] != null && blocks[x, y].IsDestructible)
                blocks[x, y] = null;
        }
    }
}
