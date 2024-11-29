using SpaceInvaders.Utils;

using Raylib_cs;
using SpaceInvaders.Managers;

namespace SpaceInvaders
{
    public static class Game
    {
        public static void Main()
        {

            Raylib.InitWindow(Constants.WINDOW_WIDTH, Constants.WINDOW_HEIGHT, "Space Invaders");
            Raylib.SetTargetFPS(60);

            GameManager.Initialize();

            while (!Raylib.WindowShouldClose())
            {
                GameManager.Update();
                GameManager.Draw();
            }

            Raylib.CloseWindow();
        }
    }
}