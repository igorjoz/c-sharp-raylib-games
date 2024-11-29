using Raylib_cs;
using SpaceInvaders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Managers
{
    public static class InputManager
    {
        public static void HandleInput(Player player, List<Bullet> bullets)
        {
            if (Raylib.IsKeyDown(KeyboardKey.Left))
            {
                player.MoveLeft();
            }
            if (Raylib.IsKeyDown(KeyboardKey.Right))
            {
                player.MoveRight();
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                bullets.Add(player.Shoot());
            }
        }
    }
}