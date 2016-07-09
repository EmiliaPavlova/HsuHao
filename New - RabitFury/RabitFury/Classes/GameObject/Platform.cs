namespace RabitFury.Classes.GameObject
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Interfaces;
    using Enums;

    public class Platform : Collidable, IRenderable, ICollidable
    {
        public Platform(Vector2 setPos, Vector2 setSize, Color setColor, Texture2D setTexture, PlatformType material) 
            : base(setPos, setSize, setColor, setTexture)
        {
            this.MaterialID = material;
        }

        public PlatformType MaterialID { get; set; } 
    }
}