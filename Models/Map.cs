using elephantocracy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Models
{
    public class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private Block[,] blocks;

        public Map(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            blocks = new Block[width, height];
        }

        public Block GetBlock(int x, int y)
        {
            if (InBounds(x, y))
                return blocks[x, y];
            return null;
        }

        public bool InBounds(int x, int y)
        {
            return x >= 0 && x < Width &&
                   y >= 0 && y < Height;
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
