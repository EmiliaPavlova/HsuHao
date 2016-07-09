namespace RabitFury.Classes.GameObject
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Collectable : GameObject, ICollectable
    {
        private bool hasCollide;

        public Collectable(Vector2 setPos, Vector2 setSize, Color setColor, Texture2D setTexture)
            : base(setPos, setSize, setColor, setTexture)
        {
            this.hasCollide = false;
        }

        public bool HasCollide(Vector2 thePoint)
        {
            if (thePoint.X >= Position.X - (Size.X / 2) &&
                thePoint.X <= Position.X + (Size.X / 2) &&
                thePoint.Y >= Position.Y - (Size.Y / 2) &&
                thePoint.Y <= Position.Y + (Size.Y / 2))
            {
                return true;
            }
            return false;
        }

        public void AddPoints()
        {
            throw new System.NotImplementedException();
        }
    }
}