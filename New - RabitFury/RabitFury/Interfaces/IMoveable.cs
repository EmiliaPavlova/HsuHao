namespace RabitFury.Interfaces
{
    using Microsoft.Xna.Framework;
    public interface IMoveable : IRenderable
    {
        Vector2 Velocity { get; set; }
        Vector2[] CollisionPoints { get; set; }
    }
}
