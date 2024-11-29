using Microsoft.VisualBasic;
using Raylib_cs;
using SpaceInvaders.Managers;
using SpaceInvaders.Utils;

namespace SpaceInvaders
{
    public static class Game
    {
        public static void Main()
        {

            Raylib.InitWindow(Utils.Constants.WINDOW_WIDTH, Utils.Constants.WINDOW_HEIGHT, "Space Invaders");
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
