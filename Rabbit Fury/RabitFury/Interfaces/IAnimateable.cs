namespace RabitFury.Interfaces
{
    using Microsoft.Xna.Framework;
    public interface IAnimateable : IRenderable
    {
        Rectangle ViewRect { get; }

        Vector2 DefaktoSize { get; }

        float CurrentFrame { get; }

        int ActionIndex { get; }

        void Animate();

        void Reset(bool touchDown);
    }
}
