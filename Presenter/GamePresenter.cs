using elephantocracy.Enums;
using elephantocracy.Interfaces;
using elephantocracy.Models;
using elephantocracy.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Presenter
{
    public class GamePresenter
    {
        private readonly IGameView _view;
        private Game _game;
        private Map _map;
        private readonly InputController _input;
        private readonly Serializator _serializator;
        private readonly System.Windows.Forms.Timer _timer;

        public Game Game => _game;
        public Map Map => _map;

        public GamePresenter(IGameView view, int lvlNum)
        {
            _view = view;
            _serializator = new Serializator("GameSaves" + lvlNum.ToString());
            _input = new InputController(Keys.W, Keys.S, Keys.A, Keys.D, Keys.Space);

            LoadInitialMap(lvlNum);

            _timer = new System.Windows.Forms.Timer { Interval = 80 };
            _timer.Tick += (s, e) => { _game.Update(); _view.RefreshView(); };
            _timer.Start();
        }

        private void LoadInitialMap(int lvlNum)
        {
            _map = _serializator.LoadMap("Map" + lvlNum.ToString() + ".json");
            var spawnService = new SpawnOnMapService();
            (int plX, int plY) = spawnService.GetPlayerSpawn(_map);

            _game = new Game(_map, _input);
            _game.Objects.Add(new Elephant(3, 1, plX, plY, Direction.Up));
            for (int i = 0; i < lvlNum; i++)
            {
                (int enX, int enY) = spawnService.GetPlaceToSpawn(_map);
                _game.Objects.Add(new Enemy(2, 1, enX, enY, Direction.Left));
            }
        }

        public void HandleKeyDown(Keys key)
        {
            switch (key)
            {
                case Keys.F5:
                    Save("manual_save");
                    break;
                case Keys.F9:
                    Load("manual_save");
                    break;
                default:
                    _input.OnKeyDown(key);
                break;
            }
        }

        public void HandleKeyUp(Keys key) => _input.OnKeyUp(key);

        public void Save(string name)
        {
            try
            {
                _serializator.SaveGame(_game, _map, name);
                _view.ShowMessage("Игра сохранена!");
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка сохранения: {ex.Message}");
            }
        }

        public void Load(string name)
        {
            try
            {
                var (game, map) = _serializator.LoadGame(name);
                _game = game;
                _map = map;
                _game.SetInputController(_input);
                _view.RefreshView();
                _view.ShowMessage("Игра загружена!");
            }
            catch (Exception ex)
            {
                _view.ShowError($"Ошибка загрузки: {ex.Message}");
            }
        }
    }
}
