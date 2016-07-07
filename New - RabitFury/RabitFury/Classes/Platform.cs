namespace RabitFury.Classes
{
    using System;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;


    public class Platform : Obstacle, IAnimatable
    {
        public Platform(Vector2 setPos, Vector2 setSize, Color setColor, Texture2D setTexture) 
            : base(setPos, setSize, setColor, setTexture)
        {
        }

        public bool IfCollide(Vector2 thePoint)
        {
            if (thePoint.X >= Position.X - (Size.X/2) && thePoint.X <= Position.X + (Size.X / 2) && thePoint.Y >= Position.Y - (Size.Y / 2) && thePoint.Y <= Position.Y + (Size.Y / 2))
            {
                return true;
            }
            return false;
        }
    }
}
