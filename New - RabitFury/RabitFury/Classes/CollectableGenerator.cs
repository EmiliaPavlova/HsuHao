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

            //collectables.Add(new Collectable(new Vector2(0.8f, 0.465f), new Vector2(0.0335f, 0.05f), Color.White, theTexture[0]));
            //collectables.Add(new Collectable(new Vector2(1f, 0.47f), new Vector2(0.04f, 0.04f), Color.White, theTexture[1]));

            for (int j = 1; j < 100; j++)
            {
                float i = random.Next(1, 100) * j * 0.04f;
                //if (i > 5.0 &&
                //    (i == 9 || i == 15 || i == 17 || i == 23 || i == 29 || i == 33 || i == 35 || i == 39 || i == 45))
                //{
                //    continue;
                //}
                //else
                //{
                    collectables.Add(new Collectable(new Vector2(i, 0.465f), new Vector2(0.0335f, 0.05f), Color.White, theTexture[0]));
                //}
            }

            for (int j = 1; j < 100; j++)
            {
                float i = random.Next(1, 100) * j * 0.06f;
                collectables.Add(new Collectable(new Vector2(i, 0.47f), new Vector2(0.04f, 0.04f), Color.White, theTexture[1]));
            }

            return collectables;
        }
    }
}