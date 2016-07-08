namespace RabitFury.Classes.GameObject
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RabitFury.Interfaces;

    public class BackgroundObject : NotCollidable, IAnimatable
    {
        public BackgroundObject(Vector2 setPos, Vector2 setSize, Color setColor, Texture2D setTexture) 
            : base(setPos, setSize, setColor, setTexture)
        {
        }

    }
}
