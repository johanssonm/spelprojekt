using System;
using Spelprojekt.Entities;

namespace Spelprojekt.Infrastructure
{
    public class EventHandlerService
    {
        public class GameEventArgs : EventArgs
        {
            public Game Game { get; set; }
        }
        
        public event EventHandler<GameEventArgs> NewGameStarted;
        public event EventHandler<GameEventArgs> ShapeRotated;
        public event EventHandler<GameEventArgs> ShapeDropped;
        public event EventHandler<GameEventArgs> ShapeMovedLeft;
        public event EventHandler<GameEventArgs> ShapeMovedRight;
        public event EventHandler<GameEventArgs> GameUpdated;
        public event EventHandler<GameEventArgs> GameOver;

        public virtual void OnGameUpdated(Game game)
        {
            GameUpdated?.Invoke(this, new GameEventArgs() { Game = game });


        }


        public virtual void OnShapeRotated(Game game)
        {
            ShapeRotated?.Invoke(this, new GameEventArgs() { Game = game } );
        }

        public virtual void OnShapeDropped(Game game)
        {
            ShapeDropped?.Invoke(this, new GameEventArgs() { Game = game });
        }

        public virtual void OnShapeMovedLeft(Game game)
        {
            ShapeMovedLeft?.Invoke(this, new GameEventArgs() { Game = game });
        }

        public virtual void OnShapeMovedRight(Game game)
        {
            ShapeMovedRight?.Invoke(this, new GameEventArgs() { Game = game });
        }

        public virtual void OnGameOver(Game game)
        {
            GameOver?.Invoke(this, new GameEventArgs() { Game = game });
        }

        public virtual void OnNewGameStarted()
        {
            NewGameStarted?.Invoke(this, new GameEventArgs());
        }
    }
}
