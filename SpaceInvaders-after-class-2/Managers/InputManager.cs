using Raylib_cs;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Utils;
using System.Collections.Generic;

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
            if (Raylib.IsKeyPressed(KeyboardKey.Enter) && (GameManager.GameState.Equals(GameState.Lost) || GameManager.GameState.Equals(GameState.Won)))
            {
                GameManager.RestartGame();
            }
        }
    }
}
