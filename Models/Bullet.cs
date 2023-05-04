using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;

namespace SpaceBattle.Models
{
    internal abstract class Bullet
    {
        public Vector2 Position;
        public int Speed;
        public Size Size;
        public Texture2D BulletSprite;

        internal Bullet(Vector2 position, int speed, Size size, Texture2D bulletSprite)
        {
            Position = position;
            Speed = speed;
            Size = size;
            BulletSprite = bulletSprite;
        }

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}