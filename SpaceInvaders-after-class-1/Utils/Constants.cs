namespace SpaceInvaders.Utils
{
    public static class Constants
    {
        public static readonly int WINDOW_WIDTH = 800;
        public static readonly int WINDOW_HEIGHT = 600;

        public static readonly Vector2D PLAYER_SIZE = new Vector2D(50, 20);
        public const float PLAYER_SPEED = 5.0f;

        public static readonly Vector2D ENEMY_SIZE = new Vector2D(40, 20);
        public const float ENEMY_SPEED = 2.0f;
        public const float ENEMY_DROP_DISTANCE = 20.0f; // Distance enemies move down when changing direction
        public const int ENEMY_ROWS = 5;
        public const int ENEMY_COLUMNS = 10;

        public static readonly Vector2D BULLET_SIZE = new Vector2D(5, 10);
        public const float BULLET_SPEED = 10.0f;
    }
}
