using Microsoft.Xna.Framework;

namespace MyTest
{
    public class Player : IAnimatable, IMovable
    {
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 size;
        public int currentAction;
        private float currentFrame;

        public Player(Vector2 setPos, Vector2 setSize)
        {
            this.position = setPos;
            this.size = setSize;
            this.velocity = new Vector2(0, 0);
            this.currentAction = 0;
            this.currentFrame = 0;
        }

        public void MoveRight()
        {
            if (position.X > 0.8f)
            {
                velocity.X = 0;
            }

            Vector2 newPos = position + velocity;

            position += velocity;
        }

        public void MoveLeft()
        {
            if (position.X < 0.1f)
            {
                velocity.X = 0f;
            }

            Vector2 newPos = position + velocity;

            position -= velocity;
        }

        public void Animate()
        {
            currentFrame += 0.2f;

            if (currentFrame >= 9.5f)
            {
                currentFrame = 0f;
            }
        }

        public void Idle()
        {
            currentFrame += 0.2f;
            velocity.X = 0.00010f;

            if (currentFrame >= 9.5f)
            {
                currentFrame = 0f;
            }
        }

        public int GetFrame
        {
            get
            {
                return (int)currentFrame;
            }
        }
    }
}
