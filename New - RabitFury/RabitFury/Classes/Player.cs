namespace RabitFury.Classes
{
    using GameObject;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    public class Player : RigidBody
    {

        public Vector2 Position { get; set; }
        public Vector2 Size { get; private set; }
        public Vector2 EdgeShifts { get; set; }
        

        public Vector2[] CollisionPoints { get; private set; }
        
        
        public Player(Vector2 setPos, Vector2 setSize, Vector2 setVelicty, Color setColor, Texture2D setTexture)
            : base(setPos,setSize,setVelicty,setColor,setTexture)
        {
            EdgeShifts = new Vector2(0.37f, 0.4f);

            Position = setPos;
            Size = setSize;
            Velocity = setVelicty;
            TheColor = setColor;
            TheTexture = setTexture;

            this.CollisionPoints = new Vector2[8];
            //Right points//
            CollisionPoints[0] = new Vector2(setPos.X + (setSize.X / 2), setPos.Y - (setSize.Y * EdgeShifts.Y)); //Right-Top Point//
            CollisionPoints[1] = new Vector2(setPos.X + (setSize.X / 2), setPos.Y + (setSize.Y * EdgeShifts.Y)); //Right-Bottom Point//
            //Bottom points//
            CollisionPoints[2] = new Vector2(setPos.X + (setSize.X * EdgeShifts.X), setPos.Y + (setSize.Y / 2)); //Bottom-Right Point//
            CollisionPoints[3] = new Vector2(setPos.X - (setSize.X * EdgeShifts.X), setPos.Y + (setSize.Y / 2)); //Bottom-Right Point//
            //Left Points//
            CollisionPoints[4] = new Vector2(setPos.X - (setSize.X / 2), setPos.Y + (setSize.Y * EdgeShifts.Y)); //Left-Bottom Point//
            CollisionPoints[5] = new Vector2(setPos.X - (setSize.X / 2), setPos.Y - (setSize.Y * EdgeShifts.Y)); //Left-Top Point//
            //Top Points//
            CollisionPoints[6] = new Vector2(setPos.X - (setSize.X * EdgeShifts.X), setPos.Y - (setSize.Y / 2)); //Top-Left Point//
            CollisionPoints[7] = new Vector2(setPos.X + (setSize.X * EdgeShifts.X), setPos.Y - (setSize.Y / 2)); //Top-Right Point//
        }
        
    }
}
