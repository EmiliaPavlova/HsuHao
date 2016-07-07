namespace RabitFury.Classes
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using GameObject;
    using Enums;
    public static class MapGenerator
    {
        public static List<Platform> GeneratePlatform(Texture2D[] theTexture)
        {
            List<Platform> tempList = new List<Platform>();

            Random random = new Random();
            for (int i = 0; i < 60; i++)
            {
                if(i > 5 && (i == 9 || i == 15 || i == 17 || i == 23 || i == 29 || i == 33 || i == 35 || i == 39 || i == 45))
                {
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.54f), new Vector2(0.11f, 0.11f), Color.White, theTexture[2], PlatformType.Dirt));
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.65f), new Vector2(0.11f, 0.11f), Color.White, theTexture[8], PlatformType.Dirt));
                    for (int current = i + 4;  i < current;  i++)
                    {
                        if (i == current - 1)
                        {
                            i++;
                            break;
                        }
                        tempList.Add(new Platform(new Vector2((0.11f * i) + 0.11f, 0.65f), new Vector2(0.11f, 0.11f), Color.White, theTexture[18], PlatformType.Lava));
                    }
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.54f), new Vector2(0.11f, 0.11f), Color.White, theTexture[0], PlatformType.Dirt));
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.65f), new Vector2(0.11f, 0.11f), Color.White, theTexture[8], PlatformType.Dirt));
                }
                else
                {
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.54f), new Vector2(0.11f, 0.11f), Color.White, theTexture[1], PlatformType.Dirt));
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.65f), new Vector2(0.11f, 0.11f), Color.White, theTexture[8], PlatformType.Dirt));
                }
                if(i == 54)
                {
                    tempList.Add(new Platform(new Vector2((0.11f * i) + 0.25f, 0.22f), new Vector2(1.1f, 1.1f), Color.White, null, PlatformType.Dirt));
                }
            }

            for (int i = 0; i < 35; i++)
            {
                if (i == 4 || i == 10 || i == 12 || i == 16 || i == 18 || i == 20 || i == 23 || i == 27 )
                {
                    if(i == 4 || i == 16 || i == 18 || i == 20 || i == 28)
                    {
                        tempList.Add(new Platform(new Vector2(0.195f * i + 0.26f, 0.1f), new Vector2(0.065f, 0.065f), Color.White, theTexture[12], PlatformType.Dirt));
                        tempList.Add(new Platform(new Vector2((0.195f * i) + 0.065f + 0.26f, 0.1f), new Vector2(0.065f, 0.065f), Color.White, theTexture[13], PlatformType.Dirt));
                        tempList.Add(new Platform(new Vector2((0.195f * i) + 0.13f + 0.26f, 0.1f), new Vector2(0.065f, 0.065f), Color.White, theTexture[14], PlatformType.Dirt));
                    }
                    if (i != 18 && i != 20 && i != 28)
                    {
                        tempList.Add(new Platform(new Vector2(0.195f * i, 0.3f), new Vector2(0.065f, 0.065f), Color.White, theTexture[12], PlatformType.Dirt));
                        tempList.Add(new Platform(new Vector2((0.195f * i) + 0.065f, 0.3f), new Vector2(0.065f, 0.065f), Color.White, theTexture[13], PlatformType.Dirt));
                        tempList.Add(new Platform(new Vector2((0.195f * i) + 0.13f, 0.3f), new Vector2(0.065f, 0.065f), Color.White, theTexture[14], PlatformType.Dirt));
                    }
                }
            }
            tempList.Add(new Platform(new Vector2(0.07f , 0.22f), new Vector2(0.71f, 0.71f), Color.White, null, PlatformType.Dirt));
            tempList.Add(new Platform(new Vector2(0.00f, 0.75f), new Vector2(100f, 0.1f), Color.White, null, PlatformType.Dirt));


            return tempList;
        }
    }
}
