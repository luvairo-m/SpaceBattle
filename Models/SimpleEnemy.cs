using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceBattle.Controllers;
using System.Drawing;
using System;
using System.IO;

namespace SpaceBattle.Models
{
    internal class SimpleEnemy : Enemy
    {
        Texture2D SimpleEnemySprite;

        public SimpleEnemy(SpaceShip currentShip, int speed, Vector2 position, Size size, Texture2D SimpleEnemySprite)
            : base(currentShip, speed, position, size) { this.SimpleEnemySprite = SimpleEnemySprite; }

        public override void Update(GameTime gameTime)
        {
            File.WriteAllText("1.txt", "qwe");
            var keyboardState = Keyboard.GetState();

            EnemyController.SimpleEnemyAdding(gameTime);
            HandleAnimation(gameTime);
            HandleMovement(gameTime, keyboardState);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SimpleEnemySprite, new Vector2(Position.X - Size.Width / 2, Position.Y - Size.Height / 2), Microsoft.Xna.Framework.Color.White);
        }

        private void HandleAnimation(GameTime gameTime)
        {
            CurrentShip.Animation.Position = new(
                Position.X - CurrentShip.Size.Width / 2,
                Position.Y - CurrentShip.Size.Height / 2);
            CurrentShip.Animation.Update(gameTime);
        }

        private void HandleMovement(GameTime gameTime, KeyboardState state)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position.Y += deltaTime * Speed;
        }

        
    }


}
