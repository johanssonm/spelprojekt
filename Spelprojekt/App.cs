using Spelprojekt.Entities;
using Spelprojekt.Service;
using Spelprojekt.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TetrisUI;

namespace Spelprojekt
{
    public partial class App : GameBoard
    {
        private GameService _gameService => new GameService();
        private UserInputService _userInputManager => new UserInputService();

        private Game _game;

        private Button button1;
        private Button button2;
        private Button button3;

        private Label highscore;

        void button1_Click(object sender, EventArgs e)
        {
            _game = _gameService.StartNewGame();

            button1.Hide();
            button1.Enabled = false;

            button2.Hide();
            button2.Enabled = false;

            button3.Hide();
            button3.Enabled = false;

            highscore.Visible = false;
        }

        void button2_Click(object sender, EventArgs e)
        {
            button2.Hide();
            button2.Enabled = false;

            button3.Hide();
            button3.Enabled = false;
            
            var sb = new StringBuilder();

            sb.AppendLine("High scores");
            sb.AppendLine("");

            List<Score> scores = new List<Score>();
            var result = new List<Player>();

            //using (data)
            //{
            //    result.AddRange(_context.Players
            //        .Include(x => x.Identity)
            //        .Include(y => y.Scores)
            //        .ToList()); // TODO: Flytta till repository

            //   foreach (var contextScore in _context.Scores)
            //    {
            //        scores.Add(contextScore);
            //    }
            //}

            var highscorelist = scores.OrderByDescending(x => x.Points);


            int i = 1;

            foreach (var score in highscorelist)
            {
                sb.AppendLine($"#{i} {score.Points.ToString()}");
                i++;
            }

            highscore.Text = sb.ToString();
            highscore.Height = 200;
            highscore.Width = 150;
            highscore.Font = new Font("Arial", 14, FontStyle.Bold);
        }

        void button3_Click(object sender, EventArgs e)
        {


            //using (var context = new GameContext())
            //{
            //    context.Database.EnsureDeleted(); // TODO: Flytta till repository
            //    context.Database.EnsureCreated();

            //    context.Players.AddRange(TestPlayers.Players());

            //    context.SaveChanges();
            //}

                MessageBox.Show("Databasen seedades");
        }


        public App() : base(1000)
        {
            button1 = new Button();
            button1.Location = new Point(25, 40);
            button1.AutoSize = true;
            button1.Text = "New Game";
           

            button2 = new Button();
            button2.Location = new Point(25, 90);
            button2.AutoSize = true;
            button2.Text = "High Score";

            button3 = new Button();
            button3.Location = new Point(25, 140);
            button3.AutoSize = true;
            button3.Text = "Seed Database";


            highscore = new Label();
            highscore.Location = new Point(25, 90);
            highscore.BackColor = Color.White;

            this.Controls.Add(button1);
            this.Controls.Add(button2);
            this.Controls.Add(button3);
            this.Controls.Add(highscore);

            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
        }

        protected override void UpdateGame()
        {
            _gameService.OnGameUpdated(_game);
        }

        protected override void Render(IRender render)
        {
            GameService.RenderGame(render, _game);
        }

        protected override void Rotate()
        {
            _userInputManager.Rotate(_game);
        }

        protected override void Drop()
        {
            _userInputManager.Drop(_game);
        }


        protected override void MoveLeft()
        {
            _userInputManager.MoveLeft(_game);
        }

        protected override void MoveRight()
        {
            _userInputManager.MoveRight(_game);
        }
    }
}