namespace RabitFury.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface ICollided
    {
        bool IfCollide(Vector2 thePoint);
    }
}