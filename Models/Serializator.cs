using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace elephantocracy.Models
{
    public class Serializator
    {
        private readonly string _saveDirectory;
        private readonly JsonSerializerOptions _jsonOptions;

        public Serializator(string saveDirectory = "Saves")
        {
            _saveDirectory = saveDirectory;

            if (!Directory.Exists(_saveDirectory))
                Directory.CreateDirectory(_saveDirectory);

            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = { new JsonStringEnumConverter() }
            };
        }

        public void Save<T>(T obj, string fileName)
        {
            try
            {
                string filePath = Path.Combine(_saveDirectory, fileName);
                string json = JsonSerializer.Serialize(obj, _jsonOptions);
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Сохранено: {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения: {ex.Message}");
            }
        }

        public T Load<T>(string fileName)
        {
            string filePath = Path.Combine(_saveDirectory, fileName);
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Файл не найден: {fileName}");

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json, _jsonOptions);
        }

        public void SaveGame(Game game, Map map, string saveName)
        {
            string savePath = Path.Combine(_saveDirectory, saveName);
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            var saveData = new GameSaveData
            {
                SavedMap = map,
                Elephant = game.Objects.OfType<Elephant>().Select(e => new ElephantData(e)).FirstOrDefault(),
                Enemies = game.Objects.OfType<Enemy>().Select(e => new EnemyData(e)).ToList()
            };

            Save(saveData, Path.Combine(saveName, "save.json"));
        }

        public (Game game, Map map) LoadGame(string saveName)
        {
            var saveData = Load<GameSaveData>(Path.Combine(saveName, "save.json"));

            var map = saveData.SavedMap;

            var input = new InputController(Keys.W, Keys.S, Keys.A, Keys.D, Keys.Space);
            var game = new Game(map, input);

            if (saveData.Elephant != null)
                game.Objects.Add(saveData.Elephant.ToElephant());

            foreach (var enemyData in saveData.Enemies)
                game.Objects.Add(enemyData.ToEnemy());
            return (game, map);
        }

        public Map LoadMap(string fileName)
        {
            string path = Path.Combine("GameSaves", fileName);
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Map>(json);
        }
    }
}