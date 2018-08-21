using Spelprojekt.Data;
using Spelprojekt.Entities;
using Spelprojekt.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;
using TetrisUI;

namespace Spelprojekt
{
    public partial class App : GameBoard
    {
        private GameContext _context => new GameContext();

        private ShapeService _shapeService;

        private GameService _gameService;

        private ScoreService _scoreService;

        private Game _game;
    
        private Shape _shape => _shapeService.ShapeInPlayState;

        private Button button1;
        private Button button2;

        private Label highscore;

        private EventHandler button1_Clicks;
        void button1_Click(object sender, EventArgs e)
        {
            StartNewGame();

            button1.Hide();
            button1.Enabled = false;

            button2.Hide();
            button2.Enabled = false;

            // Prompt.ShowDialog("Enter your name", "123");
        }

        void button2_Click(object sender, EventArgs e)
        {

            button2.Hide();
            button2.Enabled = false;

            highscore = new Label();
            highscore.Location = new Point(25,90);

            var sb = new StringBuilder();

            sb.AppendLine("Highscores");
            sb.AppendLine("");

            List<Score> scores = new List<Score>();

            using (_context)
            {
                foreach (var contextScore in _context.Scores)
                {
                    scores.Add(contextScore);
                }
            }

            int i = 1;

            foreach (var score in scores)
            {
                sb.AppendLine($"#{i} {score.ScoreAmount.ToString()}");
                i++;
            }

            highscore.Text = sb.ToString();
            highscore.Height = 200;
            highscore.Width = 150;
            highscore.BackColor = Color.White;
            highscore.Font = new Font("Arial", 14, FontStyle.Bold);


            Controls.Add(highscore);

        }



        public App() : base(1000)
        {


            //Width += 100;

            button1 = new Button();
            button1.Location = new Point(25, 40);
            button1.AutoSize = true;
            button1.Text = "New Game";

            button2 = new Button();
            button2.Location = new Point(25, 90);
            button2.AutoSize = true;
            button2.Text = "High Scores";

            this.Controls.Add(button1);
            this.Controls.Add(button2);

            button1.Click += button1_Click;
            button2.Click += button2_Click;

        }

        private void StartNewGame()
        {
            _game = new Game();

            _game.GameGrid = new GameGrid(10, 20);

            _shapeService = new ShapeService();

            _gameService = new GameService();

            _scoreService = new ScoreService();

            _game.Score = new Score();

            _shapeService.ShapeInPlayState = _game.Shapes.First();

            _shapeService.ShapeInPlayState.IsInPlay = true;

        }

        protected override void UpdateGame()
        {
            _gameService?.OnGameUpdated(_shape, _game, _shapeService, _scoreService);


        }

        protected override void Render(IRender render)
        {
            _shapeService?.RenderShapes(render, _game, _shape, _shapeService);
        }

        protected override void Rotate()
        {
            _shapeService.RotateShape(_shape, _game, _gameService, _shapeService);
        }

        protected override void Drop()
        {
            _shapeService.DropShape(_shape,_game,_shapeService,_gameService);

        }


        protected override void MoveLeft()
        {
             _shapeService.MoveShapeLeft(_shape, _game, _shapeService, _gameService);
        }

        protected override void MoveRight()
        {
            _shapeService.MoveShapeRight(_shape, _game, _gameService, _shapeService);
        }

    }
}
