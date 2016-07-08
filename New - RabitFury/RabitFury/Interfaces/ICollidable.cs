namespace RabitFury.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface ICollidable
    {
        bool IfCollide(Vector2 thePoint);
    }
}