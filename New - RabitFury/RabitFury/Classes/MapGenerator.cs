namespace RabitFury.Classes
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public static class MapGenerator
    {
        public static List<Platform> GeneratePlatform(Texture2D[] theTexture)
        {
            List<Platform> tempList = new List<Platform>();

            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                if(random.Next(10) == 0 && i > 10)
                {
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.54f), new Vector2(0.11f, 0.11f), Color.White, theTexture[2]));
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.65f), new Vector2(0.11f, 0.11f), Color.White, theTexture[8]));
                    i += 3;
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.54f), new Vector2(0.11f, 0.11f), Color.White, theTexture[0]));
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.65f), new Vector2(0.11f, 0.11f), Color.White, theTexture[8]));
                }

                else
                {
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.54f), new Vector2(0.11f, 0.11f), Color.White, theTexture[1]));
                    tempList.Add(new Platform(new Vector2(0.11f * i, 0.65f), new Vector2(0.11f, 0.11f), Color.White, theTexture[8]));
                }
            }

            for (int i = 0; i < 10; i++)
            {
                int randomX = random.Next(300);
                int randomY = random.Next(40);
                tempList.Add(new Platform(new Vector2((randomX / 100f), randomY / 100f), new Vector2(0.065f, 0.065f), Color.White, theTexture[12]));
                tempList.Add(new Platform(new Vector2((randomX / 100f) + 0.065f, randomY / 100f), new Vector2(0.065f, 0.065f), Color.White, theTexture[13]));
                tempList.Add(new Platform(new Vector2((randomX / 100f) + 0.13f, randomY / 100f), new Vector2(0.065f, 0.065f), Color.White, theTexture[14]));
            }


            return tempList;
        }
    }
}
