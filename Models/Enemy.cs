using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace SpaceBattle.Models
{
    internal class Enemy
    {
        public Vector2 Position;
        public int Speed;

        public SpaceShip CurrentShip;

        internal Enemy(SpaceShip currentShip, int speed, Vector2 position)
        {
            CurrentShip = currentShip;
            Speed = speed;
            Position = position;
        }

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            HandleAnimation(gameTime);
            HandleMovement(gameTime, keyboardState);
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
