using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceBattle.GameStates;

namespace SpaceBattle
{
    public class Game1 : Game
    {
        #region Window Size
        internal const int WindowWidth = 750;
        internal const int WindowHeight = 900;
        #endregion

        #region Monogame stuff
        private State currentState;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        #endregion

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
            // currentState = new ActionState(this, Content, graphics);
            currentState = new MenuState(this, graphics, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            currentState.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }

        // Will be used in future
        public void ChangeState(State gameState) => currentState = gameState;
    }
}