namespace RabitFury.Classes.GameObject
{
    using System.Collections.Generic;
    using global::RabitFury.Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BackgroundObject : NotCollidable, IRenderable
    {
        public BackgroundObject(Vector2 setPos, Vector2 setSize, Color setColor, Texture2D setTexture)
            : base(setPos, setSize, setColor, setTexture)
        {
            this.BackgroundCollection = new List<BackgroundObject>();
        }

        public List<BackgroundObject> BackgroundCollection { get; private set; }
    }
}

