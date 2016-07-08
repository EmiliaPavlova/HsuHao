namespace RabitFury.Classes
{
    using System.Collections.Generic;
    using System.Linq;
    using GameObject;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Classes;
    public class AllCollectables
    {
        public AllCollectables(Texture2D[] collectable)
        {
            this.collectables = CollectableGenerator.GenerateCollectable(collectable);

            this.collectables.Add(new Collectable(new Vector2(0.9f, 0.45f), new Vector2(0.0335f, 0.05f), Color.White, collectable[0]));
            this.collectables.Add(new Collectable(new Vector2(1.9f, 0.45f), new Vector2(0.0335f, 0.0335f), Color.White, collectable[1]));
        }

        public List<Collectable> collectables = new List<Collectable>();

        public void Scroll(Vector2 theOffSet)
        {
            foreach (Collectable collectable in this.collectables)
            {
                collectable.Scroll(theOffSet);
            }
        }

        public bool IfCollide(Vector2 point)
        {
            return this.collectables.Cast<Collectable>().Any(r => r.HasCollide(point));
        }
    }
}