using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceBattle.Controls;
using SpaceBattle.Models;

namespace SpaceBattle.GameStates;

public class MenuState : State
{
    private readonly List<Component> components;

    private readonly Texture2D backgroundSprite;

    private readonly Background background1;
    private readonly Background background2;

    public MenuState(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content) 
        : base(game, content, graphicsDevice)
    {
        var buttonTexture = content.Load<Texture2D>("Controls/ButtonYellow");
        var buttonFont = content.Load<SpriteFont>("Fonts/Font");
        backgroundSprite = content.Load<Texture2D>("Backgrounds/simple-space-background");

        var loadGameButton = new Button(buttonTexture, buttonFont)
        {
            Position = new Vector2(Game1.WindowWidth / 2 - buttonTexture.Width / 2, 
            Game1.WindowHeight / 2 - buttonTexture.Height - 5),
            Text = "Играть",
        };

        loadGameButton.Click += LoadGameButton_Click;

        var quitGameButton = new Button(buttonTexture, buttonFont)
        {
            Position = new Vector2(Game1.WindowWidth / 2 - buttonTexture.Width / 2, Game1.WindowHeight / 2),
            Text = "Выйти",
        };

        quitGameButton.Click += QuitGameButton_Click;

        components = new List<Component>()
        {
            loadGameButton,
            quitGameButton,
        };

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

        foreach (var component in components)
            component.Draw(gameTime, spriteBatch);

        Graphics.GraphicsDevice.Clear(Color.Black);

        spriteBatch.End();
    }
    
    public override void Update(GameTime gameTime)
    {
        background1.Update(gameTime);
        background2.Update(gameTime);

        foreach (var component in components)
            component.Update(gameTime);
    }

    private void LoadGameButton_Click(object sender, EventArgs e)
    {
        Game.ChangeState(new ActionState(Game, ContentManager, Graphics));
    }
    
    private void QuitGameButton_Click(object sender, EventArgs e)
    {
        Game.Exit();
    }
}