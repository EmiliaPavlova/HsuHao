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
                tempList.Add(new Platform(new Vector2(0.045f * i, 0.54f), new Vector2(0.045f, 0.045f), Color.White, theTexture[1])); 
            }

            for (int i = 0; i < 10; i++)
            {
                int randomX = random.Next(300);
                int randomY = random.Next(56);
                tempList.Add(new Platform(new Vector2((randomX / 100f), randomY / 100f), new Vector2(0.045f, 0.045f), Color.White, theTexture[12]));
                tempList.Add(new Platform(new Vector2((randomX / 100f) + 0.045f, randomY / 100f), new Vector2(0.045f, 0.045f), Color.White, theTexture[13]));
                tempList.Add(new Platform(new Vector2((randomX / 100f) + 0.09f, randomY / 100f), new Vector2(0.045f, 0.045f), Color.White, theTexture[14]));
            }


            return tempList;
        }
    }
}
