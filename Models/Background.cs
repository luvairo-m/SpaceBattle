using Microsoft.Xna.Framework;

namespace SpaceBattle.Models
{
    internal class Background
    {
        public Vector2 Position;
        public int Speed;

        internal Background(Vector2 position, int speed)
        {
            Position = position;
            Speed = speed;
        }   

        public void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position.Y += deltaTime * Speed;

            if (Position.Y > Game1.WindowHeight)
                Position.Y = -Game1.WindowHeight;
        }
    }
}