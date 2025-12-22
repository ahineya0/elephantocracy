using elephantocracy.Enums;
using elephantocracy.Models;

namespace elephantocracy
{
    public partial class Form1 : Form
    {
        private Game _game;
        private InputController _input;
        private System.Windows.Forms.Timer _timer;

        private int CellSize = 20;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            var map = new Map(30, 30);
            _input = new InputController(Keys.W, Keys.S, Keys.A, Keys.D, Keys.Space);

            _game = new Game(map, _input);

            _game.Objects.Add(new Elephant(3, 1, 5, 5, Direction.Up));
            _game.Objects.Add(new Enemy(2, 1, 10, 10, Direction.Left));


            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 50;
            _timer.Tick += (s, e) =>
            {
                _game.Update();
                Invalidate();
            };
            _timer.Start();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            _input.OnKeyDown(e.KeyCode);
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
    }
}
