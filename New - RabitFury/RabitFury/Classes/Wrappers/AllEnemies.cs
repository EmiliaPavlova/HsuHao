using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RabitFury.Classes.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabitFury.Classes.Wrappers
{
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
