namespace RabitFury.Classes.GameObject
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using global::RabitFury.Interfaces;

    public abstract class Collidable : GameObject, IRenderable, ICollided 
    {
        public Collidable(Vector2 setPos, Vector2 setSize, Color setColor, Texture2D setTexture)
            : base(setPos, setSize, setColor, setTexture) { }

        public bool IfCollide(Vector2 thePoint)
        {
            if (thePoint.X >= Position.X - (Size.X / 2) && thePoint.X <= Position.X + (Size.X / 2) && thePoint.Y >= Position.Y - (Size.Y / 2) && thePoint.Y <= Position.Y + (Size.Y / 2))
            {
                return true;
            }
            return false;
        }
    }
}