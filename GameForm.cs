using elephantocracy.Enums;
using elephantocracy.Models;
using elephantocracy.Services;

namespace elephantocracy
{
    public partial class GameForm : Form
    {
        private Map _map;
        private Game _game;
        private InputController _input;
        private System.Windows.Forms.Timer _timer;
        private Serializator _serializator;
        ISpawnOnMapService _spawnService;

        private int CellSize = 20;

        public GameForm()
        {
            InitializeComponent();
            DoubleBuffered = true;

            _serializator = new Serializator("GameSaves");

            _map = _serializator.LoadMap("Map.json");

            _spawnService = new SpawnOnMapService();
            (int plX, int plY) = _spawnService.GetPlayerSpawn(_map);

            _input = new InputController(Keys.W, Keys.S, Keys.A, Keys.D, Keys.Space);

            _game = new Game(_map, _input);

            _game.Objects.Add(new Elephant(3, 1, plX, plY, Direction.Up));
            _game.Objects.Add(new Enemy(2, 0, 10, 10, Direction.Left));


            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 50;
            _timer.Tick += (s, e) =>
            {
                _game.Update();
                Invalidate();
            };
            _timer.Start();
        }

        private void SaveGame(string saveName)
        {
            try
            {
                _serializator.SaveGame(_game, _map, saveName);
                Console.WriteLine($"Игра сохранена как: {saveName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения: {ex.Message}");
            }
        }

        private void LoadGame(string saveName)
        {
            try
            {
                var (game, map) = _serializator.LoadGame(saveName);
                _game = game;
                _map = map;

                _game.SetInputController(_input);

                Invalidate();
                Console.WriteLine($"Игра загружена: {saveName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки: {ex.Message}");
                MessageBox.Show($"Не удалось загрузить игру: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyCode)
            {
                case Keys.F5:
                    SaveGame("manual_save");
                    MessageBox.Show("Игра сохранена!", "Сохранение");
                    break;

                case Keys.F9:
                    LoadGame("manual_save");
                    MessageBox.Show("Игра загружена!", "Загрузка");
                    break;
                default:
                    _input.OnKeyDown(e.KeyCode);
                    break;
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            _input.OnKeyUp(e.KeyCode);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawMap(e.Graphics);
        }
        private void DrawMap(Graphics g)
        {
            for (int x = 0; x < _map.Width; x++)
            {
                for (int y = 0; y < _map.Height; y++)
                {
                    Block block = _map.GetBlock(x, y);
                    Brush blockBrush = (block != null) ? GetBrushForBlock(block) : Brushes.White;

                    g.FillRectangle(blockBrush, x * CellSize, y * CellSize, CellSize, CellSize);

                    g.DrawRectangle(Pens.LightGray, x * CellSize, y * CellSize, CellSize, CellSize);
                }
            }

            foreach (var obj in _game.Objects)
            {
                Brush brush = Brushes.Black;

                if (obj is Elephant)
                    brush = Brushes.Blue;
                else if (obj is Enemy)
                    brush = Brushes.Red;
                else if (obj is Bubble)
                    brush = Brushes.LightSkyBlue;

                g.FillRectangle(
                    brush,
                    obj.X * CellSize,
                    obj.Y * CellSize,
                    CellSize,
                    CellSize
                );
            }
        }
        private Brush GetBrushForBlock(Block block)
        {
            if (!block.IsWalkable && block.Health >= 3)
                return Brushes.DarkRed;

            if (!block.IsWalkable && block.Health > 0)
                return Brushes.Orange;

            return Brushes.LightGreen;
        }
    }
}
