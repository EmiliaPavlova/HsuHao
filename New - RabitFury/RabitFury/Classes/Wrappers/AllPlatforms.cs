namespace RabitFury.Classes
{
    using System.Collections.Generic;
    using Enums;
    using GameObject;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AllPlatforms
    {
        public AllPlatforms(Texture2D[] texture)
        {
            this.Rocks = MapGenerator.GeneratePlatform(texture);
        }

        public List<Platform> Rocks { get; private set; }

        public bool HasBurned { get; private set; }

        public void Scroll(Vector2 theOffSet)
        {
            for (int i = 0; i < Rocks.Count; i++)
            {
                Rocks[i].Scroll(theOffSet);
            }
        }

        public bool IfCollide(Vector2 point)
        {
            foreach (Platform r in Rocks)
            {
                if (r.IfCollide(point))
                {
                    if (r.MaterialID == PlatformType.Lava)
                    {
                        HasBurned = true;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}