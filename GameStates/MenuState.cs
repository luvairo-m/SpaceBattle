using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceBattle.Controls;

namespace SpaceBattle.GameStates;

public class MenuState : State
{
    private List<Component> components;

    public MenuState(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content) 
        : base(game, content, graphicsDevice)
    {
        var buttonTexture = content.Load<Texture2D>("Controls/Button");
        var buttonFont = content.Load<SpriteFont>("Fonts/Font");

        var loadGameButton = new Button(buttonTexture, buttonFont)
        {
            Position = new Vector2(185, 346),
            Text = "Game",
        };

        loadGameButton.Click += LoadGameButton_Click;

        var quitGameButton = new Button(buttonTexture, buttonFont)
        {
            Position = new Vector2(185, 496),
            Text = "Quit",
        };

        quitGameButton.Click += QuitGameButton_Click;

        components = new List<Component>()
        {
            loadGameButton,
            quitGameButton,
        };
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        foreach (var component in components)
            component.Draw(gameTime, spriteBatch);

        spriteBatch.End();
    }
    
    public override void Update(GameTime gameTime)
    {
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