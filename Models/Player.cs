using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Drawing;

namespace SpaceBattle.Models
{
    internal class Player 
    {
        public Vector2 Position;
        public int Speed;

        public int ShootingMultiplier = 3;
        public bool IsShooting;

        public static List<Bullet> Bullets = new();

        public SpaceShip CurrentShip;

        internal Player(SpaceShip currentShip, int speed)
        {
            CurrentShip = currentShip;  
            Speed = speed;  
        }

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            HandleAnimation(gameTime);
            HandleMovement(gameTime, keyboardState);
            HandleShooting(keyboardState);
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

            if (state.IsKeyDown(Keys.Left) && Position.X > CurrentShip.Size.Width / 2)
                Position.X -= deltaTime * Speed;
            if (state.IsKeyDown(Keys.Right) && Position.X < Game1.WindowWidth - CurrentShip.Size.Width / 2)
                Position.X += deltaTime * Speed;
            if (state.IsKeyDown(Keys.Up) && Position.Y > CurrentShip.Size.Height / 2)
                Position.Y -= deltaTime * Speed;
            if (state.IsKeyDown(Keys.Down) && Position.Y < Game1.WindowHeight - CurrentShip.Size.Height / 2)
                Position.Y += deltaTime * Speed;
        }

        private void HandleShooting(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Space) && !IsShooting)
            {
                var step = (float)CurrentShip.Size.Width / (ShootingMultiplier * 2);
                var buffer = Position.X - CurrentShip.Size.Width / 2;

                for (var i = 0; i < ShootingMultiplier; i++)
                {
                    var placement = buffer + step;
                    buffer = placement + step;

                    Bullets.Add(new Bullet(new(placement, Position.Y), 800, new Size(6, 22)));
                }

                IsShooting = true;
            } else if (state.IsKeyUp(Keys.Space) && IsShooting)
                IsShooting = false;
        }
    }
}