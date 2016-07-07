namespace RabitFury.Classes
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RabitFury.Interfaces;

    public abstract class Obstacles : GameObject, IAnimatable
    {
        public Obstacles(Vector2 setPos, Vector2 setSize, Color setColor, Texture2D setTexture)
            : base(setPos, setSize, setColor, setTexture)
        {
        }

        // TO DO 
    }
}
