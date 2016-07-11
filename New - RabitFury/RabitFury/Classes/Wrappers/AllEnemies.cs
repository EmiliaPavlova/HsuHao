using RabitFury.Classes.GameObject;

namespace RabitFury.Classes.Wrappers
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    public class AllEnemies
    {

        List<Enemy> listEnemies;


        public AllEnemies(Texture2D[] allTextures)
        {
            listEnemies = new List<Enemy>();
            listEnemies.Add(new Enemy(new Vector2(1.9f, 0.1f), new Vector2(0.02f, 0.02f), new Vector2(0, 0), Color.White, allTextures[0]));
        }

        public void Scroll(Vector2 ammount)
        {
            foreach (Enemy e in this.listEnemies)
            {
                e.Scroll(ammount);
            }
        }

        public IEnumerable<Enemy> ListEnemies
        {
            get
            {
                return listEnemies;
            }
        }






    }
}
