namespace RabitFury.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IRenderable
    {
        Texture2D TheTexture { get; }

        Vector2 Position { get; }

        Color TheColor { get; }

        Vector2 Size { get; }
    }
}