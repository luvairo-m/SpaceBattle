using Microsoft.Xna.Framework;
using SpaceBattle.Models;
using System;
using System.Collections.Generic;

namespace SpaceBattle.Controllers
{
    internal class EnemiesController
    {
        public List<Enemy> CurrentEnemies = new();
        private Random randomizer = new();
        private float spawnInterval = 2f;

        public void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            spawnInterval -= delta;

            if (spawnInterval <= 0)
            {
                spawnInterval = 2f;

                var value = randomizer.Next(2);
                ShipType type;

                if (value == 1) type = ShipType.RedDestroyer;
                else type = ShipType.GreenDestroyer;

                CurrentEnemies.Add(new Enemy(ShipInitializer.Initialize(type), randomizer.Next(300, 700), 
                    new(randomizer.Next(100, Game1.WindowWidth - 50), -50)));
            }

            for (var i = 0; i < CurrentEnemies.Count; i++)
            {
                CurrentEnemies[i].Update(gameTime);

                if (CurrentEnemies[i].Position.Y > Game1.WindowHeight + 50)
                    CurrentEnemies.Remove(CurrentEnemies[i]);
            }
        }
    }
}