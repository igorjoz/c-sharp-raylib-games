using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace snake
{
    public class Food
    {
        public Vector2 Position { get; private set; }
        private int screenWidth = 800;
        private int screenHeight = 640;
        private int gridSize = 40;

        public Food(int screenWidth, int screenHeight, int gridSize)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.gridSize = gridSize;
            GenerateNewPosition();
        }

        public void GenerateNewPosition()
        {
            Random random = new Random();
            int x = random.Next(0, screenWidth / gridSize) * gridSize;
            int y = random.Next(0, screenHeight / gridSize) * gridSize;
            Position = new Vector2(x, y);
        }

        public void Draw()
        {
            Raylib.DrawRectangle((int)Position.X, (int)Position.Y, gridSize, gridSize, Raylib_cs.Color.Magenta);
        }
    }
}