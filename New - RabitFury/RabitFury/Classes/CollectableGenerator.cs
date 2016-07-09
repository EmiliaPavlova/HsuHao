namespace RabitFury.Classes
{
    using System.Collections.Generic;
    using GameObject;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class CollectableGenerator
    {
        public static List<Collectable> GenerateCollectable(Texture2D[] theTexture)
        {
            List<Collectable> collectables = new List<Collectable>();

            //collectables.Add(new Collectable(new Vector2(0.8f, 0.465f), new Vector2(0.0335f, 0.05f), Color.White, theTexture[0]));
            //collectables.Add(new Collectable(new Vector2(1f, 0.47f), new Vector2(0.04f, 0.04f), Color.White, theTexture[1]));
            //collectables.Add(new Collectable(new Vector2(1f, 0.35f), new Vector2(0.03f, 0.03f), Color.White, theTexture[2]));

            for (int i = 6, index = 1; i < 200; i += 2, index++)
            {
                collectables.Add(new Collectable(new Vector2(i * index * 0.1f, 0.35f), new Vector2(0.03f, 0.03f), Color.White, theTexture[2]));
                collectables.Add(new Collectable(new Vector2(i * index * 0.25f, 0.3f), new Vector2(0.03f, 0.03f), Color.White, theTexture[2]));

                if (i < 9 || i > 12 && i < 16 || i > 19 && i < 24 || i > 26 && i < 30 || i > 33 && i < 35 || i > 39 && i < 45 || i > 48)
                {
                    if (i % 4 == 0)
                    {
                        collectables.Add(new Collectable(new Vector2(0.11f * i, 0.47f), new Vector2(0.04f, 0.04f),
                            Color.White, theTexture[1]));
                    }
                    else
                    {
                        collectables.Add(new Collectable(new Vector2(0.11f * i, 0.465f), new Vector2(0.0335f, 0.05f),
                            Color.White, theTexture[0]));
                    }
                }
            }

            return collectables;
        }
    }
}