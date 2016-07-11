namespace RabitFury.Classes.GameObject
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class RigidBody : IMoveable, ICollidable, ICollided
    {
        public Vector2[] CollisionPoints { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 Size { get; set; }

        public Color TheColor { get; set; }

        public Texture2D TheTexture { get; set; }

        public Vector2 Velocity { get; set; }

        public RigidBody(Vector2 setPos, Vector2 setSize, Vector2 setVelicty, Color setColor, Texture2D setTexture)
        {
            Position = setPos; Size = setSize; Velocity = setVelicty;
            TheColor = setColor; TheTexture = setTexture;
        }

        public virtual void InteractWithWorld(AllPlatforms platforms)
        {
            if (platforms.IfCollide(CollisionPoints[0])) // Possibly more than 1 collision points//
            {
                //TODO: 
            }
        }

        public virtual bool IfCollide(Vector2 thePoint)
        {
            if (thePoint.X >= Position.X - (Size.X / 2) && thePoint.X <= Position.X + (Size.X / 2) && thePoint.Y >= Position.Y - (Size.Y / 2) && thePoint.Y <= Position.Y + (Size.Y / 2))
            {
                return true;
            }

            return false;
        }
    }
}
