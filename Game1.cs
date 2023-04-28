using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceBattle.Models;
using System;
using System.Collections.Generic;

namespace SpaceBattle
{
    public class Game1 : Game
    {
        internal const int WindowWidth = 750;
        internal const int WindowHeight = 900;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public static Texture2D blueBirdSpriteSheet;
        public static Texture2D redDestroyerSpriteSheet;
        private Texture2D backgroundSprite;
        private Texture2D redBulletSprite;

        private Player player;
        private Background background1;
        private Background background2;

        private Random randomizer = new();
        internal static List<Enemy> Enemies = new();
        private double timer = 5d;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            blueBirdSpriteSheet = Content.Load<Texture2D>("SpaceShips/Player/blue-bird");
            redDestroyerSpriteSheet = Content.Load<Texture2D>("SpaceShips/Enemy/red-destroyer");
            backgroundSprite = Content.Load<Texture2D>("Backgrounds/simple-space-background");
            redBulletSprite = Content.Load<Texture2D>("Bullets/red-bullet");

            player = new(ShipInitializer.Initialize(ShipType.BlueBird), 250, new(WindowWidth / 2, WindowHeight - 100));

            background1 = new Background(new(0, -WindowHeight), 250);
            background2 = new Background(new(), 250);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            background1.Update(gameTime);
            background2.Update(gameTime);

            player.Update(gameTime);

            for (var i = 0; i < Player.Bullets.Count; i++)
                Player.Bullets[i].Update(gameTime); 

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(backgroundSprite,
                new Rectangle((int)background1.Position.X, (int)background1.Position.Y,
                WindowWidth, WindowHeight), Color.White);
            spriteBatch.Draw(backgroundSprite,
                new Rectangle((int)background2.Position.X, (int)background2.Position.Y,
                WindowWidth, WindowHeight), Color.White);

            player.CurrentShip.Animation.Draw(spriteBatch);

            foreach (var bullet in Player.Bullets)
                spriteBatch.Draw(redBulletSprite,
                    new Vector2(bullet.Position.X - bullet.Size.Width / 2, bullet.Position.Y - bullet.Size.Height / 2),
                    Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}