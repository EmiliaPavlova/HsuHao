namespace RabitFury.Classes
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using GameObject;
    using Classes;

    public class AllCollectables
    {
        public AllCollectables(Texture2D[] collectable)
        {
            this.collectables = CollectableGenerator.GenerateCollectable(collectable);
        }

        public List<Collectable> collectables = new List<Collectable>();

        public void Scroll(Vector2 theOffSet)
        {
            foreach (Collectable collectable in this.collectables)
            {
                collectable.Scroll(theOffSet);
            }
        }

        public bool IfCollide(Vector2 point,Player thePlayer)
        {
            return this.collectables.Cast<Collectable>().Any(r => r.HasCollide(point));
        }
    }
}