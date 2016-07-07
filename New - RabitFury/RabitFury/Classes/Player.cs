using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabitFury.Classes
{
    using Microsoft.Xna.Framework;
    public class Player
    {
        private const float playerX = 0.5f; //Probably not subject to changing//
        private const float playerY = 0.420f; //Might need to change//
        private const float edgeShiftX = 0.4f; //Collsion snappynesss ,  0 to 0.5 , center to corner X //
        private const float edgeShiftY = 0.43f; //Collsion snappynesss ,  0 to 0.5 , center to corner Y //

        public Vector2 Size { get; private set; }

        public Vector2[] CollisionPoints { get; private set; }

        public Player(Vector2 setSize)
        {
            this.Size = setSize;
            this.CollisionPoints = new Vector2[8];
            //Right points//
            CollisionPoints[0] = new Vector2(playerX + (setSize.X / 2), playerY - (setSize.Y * edgeShiftY)); //Right-Top Point//
            CollisionPoints[1] = new Vector2(playerX + (setSize.X / 2), playerY + (setSize.Y * edgeShiftY)); //Right-Bottom Point//
            //Bottom points//
            CollisionPoints[2] = new Vector2(playerX + (setSize.X * edgeShiftX), playerY + (setSize.Y / 2)); //Bottom-Right Point//
            CollisionPoints[3] = new Vector2(playerX - (setSize.X * edgeShiftX), playerY + (setSize.Y / 2)); //Bottom-Right Point//
            //Left Points//
            CollisionPoints[4] = new Vector2(playerX - (setSize.X / 2), playerY + (setSize.Y * edgeShiftY)); //Left-Bottom Point//
            CollisionPoints[5] = new Vector2(playerX - (setSize.X / 2), playerY - (setSize.Y * edgeShiftY)); //Left-Top Point//
            //Top Points//
            CollisionPoints[6] = new Vector2(playerX - (setSize.X * edgeShiftX), playerY - (setSize.Y / 2)); //Top-Left Point//
            CollisionPoints[7] = new Vector2(playerX + (setSize.X * edgeShiftX), playerY - (setSize.Y / 2)); //Top-Right Point//
        }



        public static Vector2 Position
        {
            get
            {
                return new Vector2(playerX, playerY);
            }
        }
    }
}
