namespace RabitFury.Classes.GameObject
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Collectable : Collidable, ICollectable
    {
        

        public Collectable(Vector2 setPos, Vector2 setSize, Color setColor, Texture2D setTexture, int setScoreValue)
            : base(setPos, setSize, setColor, setTexture)
        {
            this.ScoreValue = setScoreValue;
        }

        public int ScoreValue { get; private set; }

        public int Collect()
        {
            if (TheTexture != null)
            {
                TheTexture = null;

                return this.ScoreValue;
            }

            return 0;
        }
    }
}