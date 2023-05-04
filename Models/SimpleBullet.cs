using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceBattle.Models;
using System.Drawing;

namespace SpaceBattle.Models
{
    internal class SimpleBullet : Bullet
    {
        public SimpleBullet(Vector2 position, int speed, Size size, Texture2D BulletSprite) : base(position, speed, size, BulletSprite) { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var bullet in Player.Bullets)
                spriteBatch.Draw(BulletSprite,
                    new Vector2(bullet.Position.X - bullet.Size.Width / 2, bullet.Position.Y - bullet.Size.Height / 2),
                    Microsoft.Xna.Framework.Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position.Y -= deltaTime * Speed;

            if (Position.Y > Game1.WindowHeight)
                Position.Y = -Game1.WindowHeight;

            if (Position.Y < 0)
                Player.Bullets.Remove(this);
        }
    }
}
