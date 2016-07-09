namespace RabitFury.Classes.GameObject
{
    using System;

    using RabitFury.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class NotCollidable : GameObject, IRenderable
    {
        public NotCollidable(Vector2 setPos, Vector2 setSize, Color setColor, Texture2D setTexture) 
            : base(setPos, setSize, setColor, setTexture) { }
    }
}
