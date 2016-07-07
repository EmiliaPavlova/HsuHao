namespace RabitFury.Classes
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using GameObject;

    public class AllPlatforms
    {
        public AllPlatforms(Texture2D[] texture)
        {
            this.rocks = MapGenerator.GeneratePlatform(texture);
        }

        public List<Platform> rocks = new List<Platform>();

        public void Scroll(Vector2 theOffSet)
        {
            for (int i = 0; i < rocks.Count; i++)
            {
                rocks[i].Scroll(theOffSet);
            }
        }

        public bool IfCollide(Vector2 point)
        {
            foreach (Platform r in rocks)
            {
                if (r.IfCollide(point))
                {
                    return true;
                }
            }

            return false;
        }

    }
}