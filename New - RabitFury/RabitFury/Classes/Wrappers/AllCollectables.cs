﻿namespace RabitFury.Classes
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

        public void Collide(Vector2 point,Player thePlayer)
        {
            foreach (Collectable c in this.collectables)
            {
                if (c.HasCollide(point))
                {
                    thePlayer.Points += c.Collect();
                }
            }

        }
    }
}