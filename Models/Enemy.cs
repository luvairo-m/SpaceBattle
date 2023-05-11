using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;

namespace SpaceBattle.Models
{
    internal abstract class Enemy
    {
        public Vector2 Position;
        public int Speed;
        public SpaceShip CurrentShip;
        public Size Size;

        internal Enemy(SpaceShip currentShip, int speed, Vector2 position, Size size)
        {
            CurrentShip = currentShip;
            Speed = speed;
            Position = position;
            Size = size;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
