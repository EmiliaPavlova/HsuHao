using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabitFury.Classes.GameObject
{
    public class Enemy : RigidBody
    {
        public Enemy(Vector2 setPos, Vector2 setSize, Vector2 setVelicty, Color setColor, Texture2D setTexture)
            : base(setPos,setSize,setVelicty,setColor,setTexture)
        {
            this.CollisionPoints = new Vector2[2];
            // TODO: set two points
        }

        public void Scroll(Vector2 scroll)
        {
            this.Position += scroll;
            // TODO:Scroll the points as well += scroll
        }

        public override void InteractWithWorld(AllPlatforms platforms)
        {
            base.InteractWithWorld(platforms);
        }

        // TODO: clash with the enemy method
        // positiona e centyra. size x = width y = height

        public bool IfCollide(Vector2 thePoint)
        {
            if (thePoint.X >= Position.X - (Size.X / 2) && thePoint.X <= Position.X + (Size.X / 2) && thePoint.Y >= Position.Y - (Size.Y / 2) && thePoint.Y <= Position.Y + (Size.Y / 2))
            {
                return true;
            }
            return false;
        }



    }
}
