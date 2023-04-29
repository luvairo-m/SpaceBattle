using Cosmos;
using SpaceBattle.GameStates;
using System;

namespace SpaceBattle.Models
{
    enum ShipType
    {
        BlueBird,
        RedDestroyer
    }

    internal static class ShipInitializer
    {
        public static SpaceShip Initialize(ShipType shipType)
        {
            return shipType switch
            {
                ShipType.BlueBird => new SpaceShip
                {
                    Animation = new SpriteAnimation(ActionState.blueBirdSpriteSheet, 3, 3) 
                    { 
                        Scale = 0.2f,
                    },
                    Size = new(154, 113)
                },
                _ => throw new ArgumentException("Ship not found"),
            };
        }
    }
}