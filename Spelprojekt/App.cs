using Repositories;
using Spelprojekt.Entities;
using Spelprojekt.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Infrastructure.Contracts;
using TetrisUI;

namespace Spelprojekt
{
    public partial class App : GameBoard
    {

        private ShapeService _shapeService;

        private GameService _gameService => new GameService();

        private Game _game;
        private int _gameover { get; set; }

        private Shape _shape => (Shape)_game.ShapeInPlay;

        private Button NewGame;
        private Button HighScore;
        private Button SeedDatabase;

        private Label highscore;


        public App() : base(100)
        {
            _gameover = 0;

            var _game = new Game();

            _game.GameOver = false;

            InitButtons();

            NewGame.Click += StartNewGame;
            NewGame.Click += HideMenuItems;

            HighScore.Click += ShowHighScore;
            HighScore.Click += HideMenuItems;


        }

        private void AskUserForName()
        {
            var repo = new SqlRepository();

            var message = "Game over";

            MessageBox.Show(message);

            var player = new Player();

            player.Identity.Name = App.Prompt.ShowDialog("Enter your name", "Enter your name");

            player.Identity.Player = player;
            player.Scores.Add((Score)_game.Score);

            repo.Save(player);
        }

        private void InitButtons()
        {
            NewGame = new Button();
            NewGame.Location = new Point(25, 40);
            NewGame.AutoSize = true;
            NewGame.Text = "New Game";


            HighScore = new Button();
            HighScore.Location = new Point(25, 90);
            HighScore.AutoSize = true;
            HighScore.Text = "High Score";

            SeedDatabase = new Button();
            SeedDatabase.Location = new Point(25, 140);
            SeedDatabase.AutoSize = true;
            SeedDatabase.Text = "Seed Database";


            highscore = new Label();
            highscore.Location = new Point(25, 90);
            highscore.BackColor = Color.White;

            this.Controls.Add(NewGame);
            this.Controls.Add(HighScore);
            this.Controls.Add(SeedDatabase);
            this.Controls.Add(highscore);
        }

        private void StartNewGame(object obj, EventArgs e)
        {
            _game = new Game();
            _gameover = 0;

            _game.GameGrid = new GameGrid(10, 20);

            _shapeService = new ShapeService();

            _game.Score = new Score();

            var shapelist = _game.Shapes.ToList();

            _game.ShapeInPlay = shapelist.PickRandom();

            _game.ShapeInPlay.IsInPlay = true;
        }

        private void ShowHighScore(object obj, EventArgs e)
        {

        }

        private void HideMenuItems (object obj, EventArgs e)
        {
            NewGame.Visible = false;
            NewGame.Enabled = false;

            HighScore.Visible = false;
            HighScore.Enabled = false;

            SeedDatabase.Visible = false;
            SeedDatabase.Enabled = false;

            highscore.Visible = false;
        }

        private void ShowMenuItems(object obj, EventArgs e)
        {
            NewGame.Visible = true;
            NewGame.Enabled = true;
            HighScore.Visible = true;
            HighScore.Enabled = true;
            SeedDatabase.Visible = true;
            SeedDatabase.Enabled = true;
            highscore.Enabled = true;
            highscore.Visible = true;
        }


        protected override void UpdateGame()
        {
            try
            {
                if (!_game.GameOver)
                {
                    _gameService.OnGameUpdated(_shape, _game);
                }

                if (_game.GameOver && _gameover == 0)
                {
                    _gameover++;
                    AskUserForName();
                    _game = new Game();
                    ShowHighScore(null, null);
                    Thread.Sleep(5000);
                    ShowMenuItems(null, null);
                    

                }

                
           
            }


            catch (NullReferenceException)
            {

            }



        }

        protected override void Render(IRender render)
        {
            try
            {
                _shapeService.RenderShapes(render, _game);
            }
            catch (Exception e)
            {

            }

        }

        protected override void Rotate()
        {
            _shapeService.RotateShape(_shape, _game);
        }

        protected override void Drop()
        {
            _shapeService.DropShape(_shape, _game);
        }


        protected override void MoveLeft()
        {
            _shapeService.MoveShapeLeft(_shape, _game);
        }

        protected override void MoveRight()
        {
            _shapeService.MoveShapeRight(_shape, _game);
        }
    }
}