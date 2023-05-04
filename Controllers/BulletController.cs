using Microsoft.Xna.Framework.Graphics;
using SpaceBattle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle.Controllers
{
    internal static class BulletController
    {
        public static List<Bullet> bullets = new();

        public static Texture2D RedBulletTexture;
    }
}

