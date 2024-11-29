using Raylib_cs;
using SpaceInvaders.Utils;

namespace SpaceInvaders.GameObjects
{
    public class Enemy : GameObject
    {
        public Enemy(Vector2D position) : base(position, Constants.ENEMY_SIZE, Color.Red)
        {
        }

        public void Update(float direction)
        {
            Move(new Vector2D(Constants.ENEMY_SPEED * direction, 0));
        }

        public override void Update()
        {
            // Implement any additional logic here if necessary
        }
    }
}
