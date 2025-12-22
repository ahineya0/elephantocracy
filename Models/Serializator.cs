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

        // Простой метод сохранения любого объекта
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

        // Простой метод загрузки
        public T Load<T>(string fileName)
        {
            try
            {
                string filePath = Path.Combine(_saveDirectory, fileName);
                if (!File.Exists(filePath))
                    throw new FileNotFoundException($"Файл не найден: {fileName}");

                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<T>(json, _jsonOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки {fileName}: {ex.Message}");
                throw;
            }
        }

        // Сохраняем игру
        public void SaveGame(Game game, Map map, string saveName)
        {
            try
            {
                // Создаем подпапку для сохранения
                string savePath = Path.Combine(_saveDirectory, saveName);
                if (!Directory.Exists(savePath))
                    Directory.CreateDirectory(savePath);

                // Собираем данные для сохранения
                var saveData = new GameSaveData
                {
                    MapWidth = map.Width,
                    MapHeight = map.Height,
                    Elephant = game.Objects.OfType<Elephant>()
                        .Select(e => new ElephantData(e))
                        .FirstOrDefault(),
                    Enemies = game.Objects.OfType<Enemy>()
                        .Select(e => new EnemyData(e))
                        .ToList()
                };

                // Сохраняем все в один файл
                Save(saveData, Path.Combine(saveName, "save.json"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения игры: {ex.Message}");
            }
        }

        // Загружаем игру
        public (Game game, Map map) LoadGame(string saveName)
        {
            try
            {
                // Загружаем данные
                var saveData = Load<GameSaveData>(Path.Combine(saveName, "save.json"));

                // Восстанавливаем карту
                var map = new Map(saveData.MapWidth, saveData.MapHeight);

                // Создаем новую игру
                var input = new InputController(Keys.W, Keys.S, Keys.A, Keys.D, Keys.Space);
                var game = new Game(map, input);

                // Восстанавливаем объекты
                if (saveData.Elephant != null)
                    game.Objects.Add(saveData.Elephant.ToElephant());

                foreach (var enemyData in saveData.Enemies)
                    game.Objects.Add(enemyData.ToEnemy());


                Console.WriteLine($"Загружено: 1 слон, {saveData.Enemies.Count} врагов");
                return (game, map);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки игры: {ex.Message}");
                throw;
            }
        }

        public Map LoadMap(string fileName)
        {
            string path = Path.Combine("GameSaves", fileName);
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Map>(json);
        }
    }
}