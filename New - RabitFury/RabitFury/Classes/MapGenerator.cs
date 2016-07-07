namespace RabitFury.Classes
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using GameObject;

    public static class MapGenerator
    {
        public static List<Platform> GeneratePlatform(Texture2D[] theTexture)
        {
            List<Platform> tempList = new List<Platform>();

            Random random = new Random();
            for (int i = 0; i < 41; i++)
            {
                if(i > 5 && (i == 9 || i == 15 || i == 17 || i == 23 || i == 29))
                {
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.54f), new Vector2(0.11f, 0.11f), Color.White, theTexture[2]));
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.65f), new Vector2(0.11f, 0.11f), Color.White, theTexture[8]));
                    i += 4;
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.54f), new Vector2(0.11f, 0.11f), Color.White, theTexture[0]));
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.65f), new Vector2(0.11f, 0.11f), Color.White, theTexture[8]));
                }
                else
                {
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.54f), new Vector2(0.11f, 0.11f), Color.White, theTexture[1]));
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.65f), new Vector2(0.11f, 0.11f), Color.White, theTexture[8]));
                }
                if(i == 38)
                {
                    tempList.Add(new Platform(new Vector2((0.11f * i) + 0.25f, 0.22f), new Vector2(1.1f, 1.1f), Color.White, null));
                }
            }

            for (int i = 0; i < 20; i++)
            {
                if (i == 4 || i == 10 || i == 12 || i == 16)
                {
                    if(i == 4 || i == 16)
                    {
                        tempList.Add(new Platform(new Vector2(0.195f * i + 0.26f, 0.1f), new Vector2(0.065f, 0.065f), Color.White, theTexture[12]));
                        tempList.Add(new Platform(new Vector2((0.195f * i) + 0.065f + 0.26f, 0.1f), new Vector2(0.065f, 0.065f), Color.White, theTexture[13]));
                        tempList.Add(new Platform(new Vector2((0.195f * i) + 0.13f + 0.26f, 0.1f), new Vector2(0.065f, 0.065f), Color.White, theTexture[14]));
                    }
                    tempList.Add(new Platform(new Vector2(0.195f * i, 0.3f), new Vector2(0.065f, 0.065f), Color.White, theTexture[12]));
                    tempList.Add(new Platform(new Vector2((0.195f * i) + 0.065f, 0.3f), new Vector2(0.065f, 0.065f), Color.White, theTexture[13]));
                    tempList.Add(new Platform(new Vector2((0.195f * i) + 0.13f, 0.3f), new Vector2(0.065f, 0.065f), Color.White, theTexture[14]));
                }
            }
            tempList.Add(new Platform(new Vector2(0.07f , 0.22f), new Vector2(0.71f, 0.71f), Color.White, null));
            tempList.Add(new Platform(new Vector2(0.00f, 0.75f), new Vector2(100f, 0.1f), Color.White, null));


            return tempList;
        }
    }
}
