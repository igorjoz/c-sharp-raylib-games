using System.Collections.Generic;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Managers;
using SpaceInvaders.Utils;

namespace SpaceInvaders.Managers
{
    public static class CollisionManager
    {
        public static void HandleCollisions(Player player, List<Enemy> enemies, List<Bullet> bullets)
        {
            // Handle bullet-enemy collisions
            foreach (var bullet in bullets)
            {
                foreach (var enemy in enemies)
                {
                    if (bullet.CollidesWith(enemy))
                    {
                        bullet.IsActive = false;
                        enemy.IsActive = false;
                        GameManager.AddScore();
                    }
                }
            }

            bullets.RemoveAll(b => !b.IsActive);
            enemies.RemoveAll(e => !e.IsActive);

            // Handle player-enemy collisions
            foreach (var enemy in enemies)
            {
                if (enemy.CollidesWith(player))
                {
                    player.IsActive = false;
                    GameManager.SetGameState(GameState.Lost);
                    break;
                }
            }

            // Handle enemy-bottom collisions
            foreach (var enemy in enemies)
            {
                if (enemy.Position.Y + enemy.Size.Y / 2 >= Constants.WINDOW_HEIGHT)
                {
                    GameManager.SetGameState(GameState.Lost);
                    break;
                }
            }
        }
    }
}
