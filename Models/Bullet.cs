using Microsoft.Xna.Framework;
using System.Drawing;

namespace SpaceBattle.Models
{
    internal class Bullet
    {
        public Vector2 Position;
        public int Speed;
        public Size Size;

        internal Bullet(Vector2 position, int speed, Size size)
        {
            Position = position;
            Speed = speed;
            Size = size;
        }

        public void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position.Y -= deltaTime * Speed;

            if (Position.Y > Game1.WindowHeight)
                Position.Y = -Game1.WindowHeight;
        }
    }
}