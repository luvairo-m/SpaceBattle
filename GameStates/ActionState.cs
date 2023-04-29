﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceBattle.Models;

namespace SpaceBattle.GameStates
{
    internal class ActionState : State
    {
        #region Textures
        public static Texture2D blueBirdSpriteSheet;
        private readonly Texture2D backgroundSprite;
        private readonly Texture2D redBulletSprite;

        private readonly Background background1;
        private readonly Background background2;
        #endregion

        #region Player
        private Player player;
        #endregion

        public ActionState(Game1 game, ContentManager contentManager, GraphicsDeviceManager graphics)
            : base(game, contentManager, graphics)
        {
            blueBirdSpriteSheet = contentManager.Load<Texture2D>("SpaceShips/Player/blue-bird");
            backgroundSprite = contentManager.Load<Texture2D>("Backgrounds/simple-space-background");
            redBulletSprite = contentManager.Load<Texture2D>("Bullets/red-bullet");

            player = new(ShipInitializer.Initialize(ShipType.BlueBird), 250, new(Game1.WindowWidth / 2, Game1.WindowHeight - 100));

            background1 = new Background(new(0, -Game1.WindowHeight), 250);
            background2 = new Background(new(), 250);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(backgroundSprite,
                new Rectangle((int)background1.Position.X, (int)background1.Position.Y,
                Game1.WindowWidth, Game1.WindowHeight), Color.White);
            spriteBatch.Draw(backgroundSprite,
                new Rectangle((int)background2.Position.X, (int)background2.Position.Y,
                Game1.WindowWidth, Game1.WindowHeight), Color.White);

            player.CurrentShip.Animation.DrawWithScale(spriteBatch);

            foreach (var bullet in Player.Bullets)
                spriteBatch.Draw(redBulletSprite,
                    new Vector2(bullet.Position.X - bullet.Size.Width / 2, bullet.Position.Y - bullet.Size.Height / 2),
                    Color.White);

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            background1.Update(gameTime);
            background2.Update(gameTime);
            player.Update(gameTime);

            for (var i = 0; i < Player.Bullets.Count; i++)
                Player.Bullets[i].Update(gameTime);
        }
    }
}