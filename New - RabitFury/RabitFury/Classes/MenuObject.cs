namespace RabitFury.Classes
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RabitFury.Interfaces;

    public class MenuObject : IAnimatable
    {
        public MenuObject(Vector2 setPos, Vector2 setSize, Color setColor, Texture2D setTexture)
        {
            this.Position = setPos;
            this.Size = setSize;
            this.TheColor = setColor;
            this.TheTexture = setTexture;
        }

        public Vector2 Position { get; set; }

        public Vector2 Size { get; set; }

        public Color TheColor { get; set; }

        public Texture2D TheTexture { get; set; }
    }
}