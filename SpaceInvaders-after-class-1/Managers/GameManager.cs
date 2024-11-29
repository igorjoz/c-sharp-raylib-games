using Raylib_cs;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Managers
{
    public static class GameManager
    {
        private static Player player;
        private static List<Bullet> bullets;
        private static GameState gameState = GameState.Playing;

        public static void Initialize()
        {
            player = new Player();
            bullets = new List<Bullet>();

        }

        public static void Update()
        {
            if (gameState == GameState.Playing)
            {

                InputManager.HandleInput(player, bullets);

                player.Update();

                foreach (var bullet in bullets)
                {
                    bullet.Update();
                }
            }
        }

        public static void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            player.Draw();
            foreach (var bullet in bullets)
            {
                bullet.Draw();
            }

            Raylib.EndDrawing();
        }
    }
}
