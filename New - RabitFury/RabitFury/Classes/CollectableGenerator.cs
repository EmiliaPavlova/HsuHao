namespace RabitFury.Classes
{
    using System;
    using System.Collections.Generic;
    using GameObject;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class CollectableGenerator
    {
        public static List<Collectable> GenerateCollectable(Texture2D[] theTexture)
        {
            List<Collectable> collectables = new List<Collectable>();

            Random random = new Random();

            //TODO: Check positions with Platform

            collectables.Add(new Collectable(new Vector2(0.07f, 0.22f), new Vector2(0.71f, 0.71f), Color.White, null));
            collectables.Add(new Collectable(new Vector2(0.00f, 0.75f), new Vector2(100f, 0.1f), Color.White, null));

            return collectables;
        }
    }
}