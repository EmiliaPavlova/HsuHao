namespace RabitFury.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IAnimatable
    {
        Texture2D TheTexture { get; set; }

        Vector2 Position { get; set; }

        Color TheColor { get; set; }

        Vector2 Size { get; set; }
    }
}