namespace RabitFury.Interfaces
{
    using Microsoft.Xna.Framework;
    public interface IMoveable : IRenderable
    {
        Vector2 Velocity { get; }
        Vector2[] CollisionPoints { get; }
    }
}
