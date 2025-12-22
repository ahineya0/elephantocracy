using elephantocracy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Services
{
    public class SpawnOnMapService : ISpawnOnMapService
    {
        private const int SpawnHealthMarker = 67;

        public (int X, int Y) GetPlayerSpawn(Map map)
        {
            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    Block block = map.GetBlock(x, y);
                    if (block != null &&
                        block.IsWalkable &&
                        block.Health == SpawnHealthMarker)
                    {
                        return (x, y);
                    }
                }
            }

            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    if (map.IsWalkable(x, y))
                        return (x, y);
                }
            }
            return (0, 0);
        }
        public (int X, int Y) GetPlaceToSpawn(Map map)
        {
            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    if (map.IsWalkable(x, y))
                        return (x, y);
                }
            }
            return (0, 0);
        }
    }
}
