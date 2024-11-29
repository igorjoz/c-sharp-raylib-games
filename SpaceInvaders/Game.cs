using Microsoft.VisualBasic;
using Raylib_cs;
using SpaceInvaders.Managers;

namespace SpaceInvaders
{
    public class Game
    {
        public static void Main(string[] args)
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
