using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabitFury.Interfaces
{
    using Microsoft.Xna.Framework;
    public interface IMoveable : IRenderable
    {
        Vector2 Velocity { get; set; }
        Vector2[] CollisionPoints { get; set; }
    }
}
