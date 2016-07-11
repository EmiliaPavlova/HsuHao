namespace RabitFury.Classes.GameObject
{
    using Enums;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Platform : Collidable, IRenderable, ICollided
    {
        public Platform(Vector2 setPos, Vector2 setSize, Color setColor, Texture2D setTexture, PlatformType material)
            : base(setPos, setSize, setColor, setTexture)
        {
            this.MaterialID = material;
        }

        public PlatformType MaterialID { get; private set; }
    }
}