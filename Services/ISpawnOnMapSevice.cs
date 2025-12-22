using elephantocracy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Services
{
    public interface ISpawnOnMapService
    {
        (int X, int Y) GetPlayerSpawn(Map map);
    }
}
