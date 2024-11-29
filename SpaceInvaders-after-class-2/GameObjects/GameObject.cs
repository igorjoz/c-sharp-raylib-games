using Raylib_cs;
using SpaceInvaders.Utils;

namespace SpaceInvaders.GameObjects
{
    public abstract class GameObject
    {
        private Vector2D _position;
        public Vector2D Position
        {
            get => _position;
            private set => _position = value;
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

        public void Move(Vector2D delta)
        {
            _position += delta;
        }

        public void SetPosition(Vector2D position)
        {
            _position = position;
        }

        public abstract void Update();

        public void Draw()
        {
            Raylib.DrawRectangle((int)(_position.X - Size.X / 2), (int)(_position.Y - Size.Y / 2), (int)Size.X, (int)Size.Y, Color);
        }

        public bool CollidesWith(GameObject other)
        {
            return !(_position.X + Size.X / 2 < other.Position.X - other.Size.X / 2 ||
                     _position.X - Size.X / 2 > other.Position.X + other.Size.X / 2 ||
                     _position.Y + Size.Y / 2 < other.Position.Y - other.Size.Y / 2 ||
                     _position.Y - Size.Y / 2 > other.Position.Y + other.Size.Y / 2);
        }
    }
}
