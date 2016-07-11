namespace RabitFury.Classes
{
    using GameObject;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class BackgroundGenerator
    {
        public static List<BackgroundObject> GenerateBackgroundObjects(Texture2D[] theTexture)
        {
            List<BackgroundObject> tempList = new List<BackgroundObject>();

            for (int i = 0; i < 7; i++)
            {
                tempList.Add(new BackgroundObject(new Vector2(0.445f + i, 0.28125f), new Vector2(1f, 1f), Color.White, theTexture[0]));
            }
            tempList.Add(new BackgroundObject(new Vector2(0.685f,  0.411f), new Vector2(0.2f, 0.3f), Color.White, theTexture[1]));
            tempList.Add(new BackgroundObject(new Vector2(0.385f, 0.411f), new Vector2(0.2f, 0.3f), Color.White, theTexture[2]));


            return tempList;
        }
    }
}
