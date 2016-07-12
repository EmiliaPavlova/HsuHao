namespace RabitFury.Interfaces
{
    using Microsoft.Xna.Framework;
    public interface ICollidable
    {
        Vector2[] CollisionPoints { get; }
    }
}
