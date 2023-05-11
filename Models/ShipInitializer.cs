using Cosmos;
using Microsoft.Xna.Framework.Graphics;
using SpaceBattle.GameStates;
using System;

namespace SpaceBattle.Models
{
    enum ShipType
    {
        BlueBird,
        RedDestroyer,
        GreenDestroyer
    }

    internal static class ShipInitializer
    {
        public static SpaceShip Initialize(ShipType shipType)
        {
            return shipType switch
            {
                ShipType.BlueBird => new SpaceShip
                {
                    Animation = new SpriteAnimation(ActionState.BlueBirdSpriteSheet, 3, 3) 
                    { 
                        Scale = 0.2f,
                    },
                    Size = new(154, 113)
                },
                ShipType.RedDestroyer => new SpaceShip
                {
                    Animation = new SpriteAnimation(ActionState.RedDestroyerSpriteSheet, 5, 4)
                    {
                        SpriteEffect = SpriteEffects.FlipVertically
                    },
                    Size = new(154, 113)
                },
                ShipType.GreenDestroyer => new SpaceShip
                {
                    Animation = new SpriteAnimation(ActionState.GreenDestroyerSpriteSheet, 5, 4)
                    {
                        SpriteEffect = SpriteEffects.FlipVertically
                    },
                    Size = new(154, 113)
                },
                _ => throw new ArgumentException("Ship not found"),
            };
        }
    }
}