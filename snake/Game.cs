using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace snake
{
    public class Game
    {
        private bool gameOver;
        private int screenWidth = 800;
        private int screenHeight = 640;
        private int gridSize = 40;
        private int score = 0;
        private int speed = 10;
        private Snake snake;
        private Food food;

        public void Run()
        {
            Initialize();
            while (!Raylib.WindowShouldClose())
            {
                Draw();
                Update();
            }
        }

        private void Update()
        {
            if (gameOver)
            {
                if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                {
                    RestartGame();
                }

                return;
            }

            if (snake.CheckCollision(food.Position))
            {
                snake.Grow();
                food.GenerateNewPosition();
                score++;
                speed = Math.Min(30, speed + 1);
                Raylib.SetTargetFPS(speed);
            }

            if (Raylib.IsKeyPressed(KeyboardKey.Up))
            {
                snake.ChangeDirection(new Vector2(0, -1));
            }

            if (Raylib.IsKeyPressed(KeyboardKey.Down))
            {
                snake.ChangeDirection(new Vector2(0, 1));
            }

            if (Raylib.IsKeyPressed(KeyboardKey.Left))
            {
                snake.ChangeDirection(new Vector2(-1, 0));
            }

            if (Raylib.IsKeyPressed(KeyboardKey.Right))
            {
                snake.ChangeDirection(new Vector2(1, 0));
            }

            snake.Move();

            if (snake.CheckSelfCollision())
            {
                gameOver = true;
            }
        }
        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            Raylib.DrawText(score.ToString("D2"), 20, 20, 40, Color.White);

            if (gameOver)
            {
                Raylib.DrawText("Game Over", screenWidth / 2 - 180, screenHeight / 2 - 70, 70, Color.Red);
                Raylib.DrawText("Press Enter to restart", screenWidth / 2 - 180, screenHeight / 2 + 20, 30, Color.White);
            }
            else
            {
                snake.Move();
                snake.Draw();

                food.Draw();
            }

            Raylib.EndDrawing();
        }

        private void Initialize()
        {
            gameOver = false;

            Raylib.InitWindow(screenWidth, screenHeight, "Snake Game");
            Raylib.SetTargetFPS(speed);

            snake = new Snake(gridSize, screenWidth, screenHeight);
            food = new Food(screenWidth, screenHeight, gridSize);
        }

        public void RestartGame()
        {
            score = 0;
            speed = 5;
            snake = new Snake(gridSize, screenWidth, screenHeight);
            food = new Food(screenWidth, screenHeight, gridSize);
            gameOver = false;
            Raylib.SetTargetFPS(speed);
        }
    }
}
