using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabitFury.Classes
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Rock : Interfaces.IDrawable
    {
        public Vector2 Position { get; set; }

        public Vector2 Size { get; set; }

        public Color TheColor { get; set; }

        public Texture2D TheTexture { get; set; }


        public void Scroll(Vector2 alter)
        {
            Position += alter;
        }

        public Rock(Vector2 setPos,Vector2 setSize,Color setColor,Texture2D setTexture)
        {
            Position = setPos;
            Size = setSize;
            TheColor = setColor;
            TheTexture = setTexture;
        }

        public bool IfCollide(Vector2 thePoint)
        {
            if (thePoint.X >= Position.X - (Size.X/2) && thePoint.X <= Position.X + (Size.X / 2) && thePoint.Y >= Position.Y - (Size.Y / 2) && thePoint.Y <= Position.Y + (Size.Y / 2))
            {
                return true;
            }
            return false;
        }
    }
}
