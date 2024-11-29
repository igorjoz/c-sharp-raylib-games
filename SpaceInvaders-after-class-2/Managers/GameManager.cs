using Raylib_cs;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Utils;

namespace SpaceInvaders.Managers
{
    public static class GameManager
    {
        private static Player player;
        private static List<Enemy> enemies;
        private static List<Bullet> bullets;
        private static float enemyDirection = 1.0f; // 1.0f for right, -1.0f for left
        private static GameState gameState = GameState.Playing;
        private static int score = 0;
        private static float elapsedTime = 0.0f;

        // Publig getter for gameState
        public static GameState GameState
        {
            get { return gameState; }
        }

        public static void Initialize()
        {
            player = new Player();
            enemies = new List<Enemy>();
            bullets = new List<Bullet>();
            score = 0;
            elapsedTime = 0.0f;

            // Initialize enemies
            for (int i = 0; i < Constants.ENEMY_ROWS; i++)
            {
                for (int j = 0; j < Constants.ENEMY_COLUMNS; j++)
                {   // Explanation: 100 is the initial x position, 50 is the distance between each enemy
                    enemies.Add(new Enemy(new Vector2D(100 + j * 50, 50 + i * 50)));
                }
            }
        }

        public static void Update()
        {
            if (gameState == GameState.Playing)
            {
                elapsedTime += Raylib.GetFrameTime();

                InputManager.HandleInput(player, bullets);

                player.Update();

                bool changeDirection = false;

                foreach (var enemy in enemies)
                {
                    enemy.Update(enemyDirection);
                    if (enemy.Position.X >= 800 - enemy.Size.X / 2 || enemy.Position.X <= enemy.Size.X / 2)
                    {
                        changeDirection = true;
                    }
                    if (enemy.Position.Y + enemy.Size.Y / 2 >= 600)
                    {
                        gameState = GameState.Lost;
                    }
                }

                if (changeDirection)
                {
                    enemyDirection = -enemyDirection;
                    foreach (var enemy in enemies)
                    {
                        enemy.Move(new Vector2D(0, Constants.ENEMY_DROP_DISTANCE));
                    }
                }

                foreach (var bullet in bullets)
                {
                    bullet.Update();
                }

                CollisionManager.HandleCollisions(player, enemies, bullets);

                if (enemies.Count == 0)
                {
                    gameState = GameState.Won;
                }
            }
            else
            {
                if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                {
                    RestartGame();
                }
            }
        }

        public static void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            if (gameState == GameState.Playing)
            {
                player.Draw();
                foreach (var enemy in enemies)
                {
                    enemy.Draw();
                }
                foreach (var bullet in bullets)
                {
                    bullet.Draw();
                }

                // Draw score
                Raylib.DrawText($"Score: {score}", 10, 10, 20, Color.Yellow);

            } else
            {
                drawScore();
            }

            Raylib.EndDrawing();
        }

        private static void drawScore()
        {
            string messageText;
            Color messageColor;

            if (gameState == GameState.Won)
            {
                messageText = "You Win!";
                messageColor = Color.Green;
            }
            else if (gameState == GameState.Lost)
            {
                messageText = "You Lose!";
                messageColor = Color.Red;
            }
            else
            {
                return; // Exit if gameState is neither Won nor Lost
            }

            string restartText = "Press Enter to restart";
            string finalScoreText = $"Final Score: {score}";

            int messageTextWidth = Raylib.MeasureText(messageText, 40);
            int restartTextWidth = Raylib.MeasureText(restartText, 20);
            int finalScoreTextWidth = Raylib.MeasureText(finalScoreText, 20);

            int messageTextX = (Constants.WINDOW_WIDTH - messageTextWidth) / 2;
            int restartTextX = (Constants.WINDOW_WIDTH - restartTextWidth) / 2;
            int finalScoreTextX = (Constants.WINDOW_WIDTH - finalScoreTextWidth) / 2;

            Raylib.DrawText(messageText, messageTextX, 200, 40, messageColor);
            Raylib.DrawText(restartText, restartTextX, 250, 20, messageColor);
            Raylib.DrawText(finalScoreText, finalScoreTextX, 300, 20, Color.Yellow);
        }

        public static void RestartGame()
        {
            Initialize();
            gameState = GameState.Playing;
            enemyDirection = 1.0f; // Reset direction to right
        }

        public static void AddScore()
        {
            int points = (int)(1000 / elapsedTime);
            score += points;
        }

        public static void SetGameState(GameState newState)
        {
            gameState = newState;
        }
    }
}
