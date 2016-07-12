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
            listEnemies.Add(new Enemy(new Vector2(1.1f, 0.01f), new Vector2(0.05f, 0.05f), new Vector2(0, 0), Color.White, allTextures[0]));
            listEnemies.Add(new Enemy(new Vector2(1.362f, 0.34f), new Vector2(0.03f, 0.03f), new Vector2(0, 0), Color.White, allTextures[0]));

            listEnemies.Add(new Enemy(new Vector2(0.94f, 0.4f), new Vector2(0.08f, 0.08f), new Vector2(0, 0), Color.White, allTextures[0]));
            listEnemies.Add(new Enemy(new Vector2(2.31f, 0.21f), new Vector2(0.05f, 0.05f), new Vector2(0, 0), Color.White, allTextures[0]));

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
