using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics; //ta linijka dodala sie automatycznie
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace snake
{
    public class Snake
    {
        private List<Vector2> body;
        private Vector2 direction;
        private int gridSize;
        private int screenWidth;
        private int screenHeight;
        private bool grow;

        public Snake(int gridSize, int screenWidth, int screenHeight)
        {
            this.gridSize = gridSize;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            body = new List<Vector2> { new Vector2(screenWidth / 2, screenHeight / 2) };
            direction = new Vector2(1, 0);
            grow = false;
        }

        public void Draw()
        {
            foreach (var segment in body)
            {
                //Console.WriteLine("xD");
                Raylib.DrawRectangle((int)segment.X, (int)segment.Y, gridSize, gridSize, Color.Green);
            }
        }
        /// <summary>
        /// tutaj trzeba dodać warunek, że jeśli grow jest true to nie usuwamy ostatniego segmentu
        /// </summary>
        public void Move()
        {
            Vector2 newHead = body[0] + direction * gridSize;
            body.Insert(0, newHead);

            if (!grow) {
                body.RemoveAt(body.Count - 1);
            } else {
              grow = false;
            }

            body[0] = new Vector2(
                (body[0].X + screenWidth) % screenWidth,
                (body[0].Y + screenHeight) % screenHeight
            );
        }

        public void ChangeDirection(Vector2 newDirection)
        {
            if (Vector2.Dot(direction, newDirection) == 0)
            {
                direction = newDirection;
            }
        }

        public bool CheckSelfCollision()
        {
            Vector2 head = body[0];

            return body.Skip(1).Any(segment => segment == head);
        }

        /// <summary>
        /// return body.Skip(1).Any(segment => segment == head);
        /// 
        /// to to samo co:
        /// 
        /// foreach (var segment in body.Skip(1))
        //     {
        //         if (segment == head)
        //         {
        //             return true;
        //         }
        //     }
        // return false;
        /// </summary>

        public bool CheckCollision(Vector2 position)
        {
            return body.Contains(position);
        }

        public void Grow()
        {
            grow = true;
        }
    }
}
