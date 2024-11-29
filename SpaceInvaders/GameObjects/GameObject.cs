using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects
{
    public abstract class GameObject
    {
        private Vector2D _position;

        public Vector2D Position {
            get { return _position; }
            private set { _position = value; }
        }

        public Vector2D Size { get; }
        public Color Color { get; }
        public bool IsActive { get; set; }

        protected GameObject(Vector2D position, Vector2D size, Color color)
        {
            _position = position;
            Size = size;
            Color = color;
            IsActive = true;
        }
    }
}
