namespace RabitFury.Classes
{
    using System.Collections.Generic;
    using GameObject;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AllBackgroundObjects
    {
        public AllBackgroundObjects(Texture2D[] texture)
        {
            this.DynamicBackgroundObjects = MapGenerator.GenerateBackgroundObjects(texture);
        }

        public List<BackgroundObject> DynamicBackgroundObjects { get; private set; }

        public void Scroll(Vector2 theOffSet)
        {
            for (int index = 0; index < DynamicBackgroundObjects.Count; index++)
            {
                DynamicBackgroundObjects[index].Scroll(theOffSet);
            }
        }
    }
}
