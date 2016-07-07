using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabitFury.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    public interface IDrawable
    {
        Texture2D TheTexture { get;}
        Vector2 Position { get; set; }
        Color TheColor { get; set; }
        Vector2 Size { get; set; }
        
    }
}
