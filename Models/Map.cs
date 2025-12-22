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

        public Block[][] Blocks { get; set; }

        public Map() { }
        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            Blocks = new Block[width][];
            for (int x = 0; x < width; x++)
            {
                Blocks[x] = new Block[height];
                for (int y = 0; y < height; y++)
                {
                    Blocks[x][y] = new Block(true, true);
                }
            }
        }

        public Block GetBlock(int x, int y)
        {
            if (InBounds(x, y))
                return Blocks[x][y];
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

            Block block = Blocks[x][y];
            return block == null || block.IsWalkable;
        }

        public bool IsShootThrough(int x, int y)
        {
            if (!InBounds(x, y))
                return false;

            Block block = Blocks[x][y];
            return block == null || block.IsShootThrough;
        }

        public void DestroyBlock(int x, int y)
        {
            if (!InBounds(x, y)) return;

            if (Blocks[x][y] != null && Blocks[x][y].IsDestructible)
                Blocks[x][y] = new Block(true, true);
        }
    }
}
