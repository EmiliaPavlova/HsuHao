namespace RabitFury.Interfaces
{
    using Microsoft.Xna.Framework;
    public interface IAnimateable : IRenderable
    {
        Rectangle ViewRect { get; set; }
        Vector2 DefaktoSize { get; set; }
        float CurrentFrame { get; set; }
        int ActionIndex { get; set; }

        void Animate();
        void Reset(bool touchDown);
    }
}
