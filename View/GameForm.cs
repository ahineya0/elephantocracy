using elephantocracy.Enums;
using elephantocracy.Interfaces;
using elephantocracy.Models;
using elephantocracy.Presenter;
using elephantocracy.Services;
using elephantocracy.View;

namespace elephantocracy
{
    public partial class GameForm : Form, IGameView
    {
        private GamePresenter _presenter;
        public int CellSize { get; } = 20;

        public GameForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            _presenter = new GamePresenter(this);
        }

        public void RefreshView() => Invalidate();

        public void ShowError(string message) => MessageBox.Show(message, "Œ¯Ë·Í‡", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void ShowMessage(string message) => MessageBox.Show(message, "»ÌÙÓ");

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            _presenter.HandleKeyDown(e.KeyCode);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            _presenter.HandleKeyUp(e.KeyCode);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawMap(e.Graphics);
        }

        private void DrawMap(Graphics g)
        {
            var map = _presenter.Map;
            var game = _presenter.Game;

            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    Block block = map.GetBlock(x, y);
                    Brush blockBrush = GetBrushForBlock(block);
                    g.FillRectangle(blockBrush, x * CellSize, y * CellSize, CellSize, CellSize);
                    g.DrawRectangle(Pens.LightGray, x * CellSize, y * CellSize, CellSize, CellSize);
                }
            }

            foreach (var obj in game.Objects)
            {
                Brush brush = obj switch
                {
                    Elephant => Brushes.Blue,
                    Enemy => Brushes.Red,
                    Bubble => Brushes.LightSkyBlue,
                    _ => Brushes.Black
                };
                g.FillRectangle(brush, obj.X * CellSize, obj.Y * CellSize, CellSize, CellSize);
            }
        }

        private Brush GetBrushForBlock(Block block)
        {
            if (block == null) return Brushes.White;
            if (!block.IsWalkable && block.Health >= 3) return Brushes.DarkRed;
            if (!block.IsWalkable && block.Health > 0) return Brushes.Orange;
            return Brushes.LightGreen;
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            var menu = new StartMenuForm();
            menu.Show();
        }
    }
}
