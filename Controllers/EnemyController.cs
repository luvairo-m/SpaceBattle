using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceBattle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle.Controllers
{
    internal static class EnemyController
    {
        public static Random rnd = new Random();

        public static List<SimpleEnemy> simpleEnemies = new();

        public static Texture2D SimpleEnemySprite;

        public static bool is_add = false;

        public static void SimpleEnemyAdding(GameTime gameTime)
        {
            if (!is_add)
            {
                simpleEnemies.Add(new SimpleEnemy(ShipInitializer.Initialize(ShipType.RedDestroyer), 50, new(100, 50), new(300, 300), EnemyController.SimpleEnemySprite));
                is_add = true;
            }
        }
    }
}
