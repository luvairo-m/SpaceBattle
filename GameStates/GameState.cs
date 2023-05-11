using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceBattle.GameStates;

public class GameState : State
{
    public GameState(Game1 game, GraphicsDeviceManager graphics, ContentManager content) 
        : base(game, content, graphics)
    {
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {

    }

    public override void Update(GameTime gameTime)
    {

    }
}