using System.Collections.Generic;
using System.Linq;
using elephantocracy.Enums;

namespace elephantocracy.Models
{
    public class GameSaveData
    {
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }

        public ElephantData Elephant { get; set; }
        public List<EnemyData> Enemies { get; set; }

        public GameSaveData()
        {
            Enemies = new List<EnemyData>();
        }
    }
}
