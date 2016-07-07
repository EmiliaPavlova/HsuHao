namespace RabitFury.Classes.GameObject
{
    using System;

    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class GameObject : IAnimatable
    {
        public GameObject(Vector2 setPos, Vector2 setSize, Color setColor, Texture2D setTexture)
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

        public void Scroll(Vector2 alter)
        {
            Position += alter;
        }
    }
}
