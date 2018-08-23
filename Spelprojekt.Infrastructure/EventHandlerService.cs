using System;

namespace Spelprojekt.Infrastructure
{
    public class EventHandlerService
    {

        
        public event EventHandler<EventArgs> NewGameStarted;
        public event EventHandler<EventArgs> ShapeRotated;
        public event EventHandler<EventArgs> ShapeDropped;
        public event EventHandler<EventArgs> ShapeMovedLeft;
        public event EventHandler<EventArgs> ShapeMovedRight;
        public event EventHandler<EventArgs> GameUpdated;
        public event EventHandler<EventArgs> GameOver;

        public virtual void OnShapeRotated()
        {
            ShapeRotated?.Invoke(this, EventArgs.Empty);
        }

        public virtual void OnShapeDropped()
        {
            ShapeDropped?.Invoke(this, EventArgs.Empty);
        }

        public virtual void OnShapeMovedLeft()
        {
            ShapeMovedLeft?.Invoke(this, EventArgs.Empty);
        }

        public virtual void OnShapeMovedRight()
        {
            ShapeMovedRight?.Invoke(this, EventArgs.Empty);
        }

        public virtual void OnGameUpdated()
        {

            GameUpdated?.Invoke(this, EventArgs.Empty);
        }

        public virtual void OnGameOver()
        {
            GameOver?.Invoke(this, EventArgs.Empty);
        }

        public virtual void OnNewGameStarted()
        {
            NewGameStarted?.Invoke(this, EventArgs.Empty);
        }
    }
}
