namespace RabitFury.Classes
{
    using GameObject;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
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
        

        public void InteractWithWorld(AllPlatforms allPlatforms,KeyboardState keyState,float[] worldArgs)
        {
            this.Velocity = new Vector2(0, this.Velocity.Y);
            if (this.Velocity.Y < worldArgs[2]) //worldArgs[2] is MaxVelocity//
            {
                this.Velocity = new Vector2(this.Velocity.X, this.Velocity.Y + worldArgs[1]); // worldArgs[1] is Gravity//
            }

            if (keyState.IsKeyDown(Keys.Right))
            {
                this.Velocity = new Vector2(0.003f, this.Velocity.Y);
            }

            if (keyState.IsKeyDown(Keys.Left))
            {
                this.Velocity = new Vector2(-0.003f, this.Velocity.Y);
            }

            if (keyState.IsKeyDown(Keys.Up) &&
                (allPlatforms.IfCollide(this.CollisionPoints[2]) ||
                allPlatforms.IfCollide(this.CollisionPoints[3])))
            {
                this.Velocity = new Vector2(this.Velocity.X, -worldArgs[0]); //worldArgs[0] is JumpPower//
            }



            if (allPlatforms.IfCollide(this.CollisionPoints[0]) ||
                        allPlatforms.IfCollide(this.CollisionPoints[1]))
            {
                if (this.Velocity.X > 0) this.Velocity = new Vector2(0, this.Velocity.Y);
            }
            else if (allPlatforms.IfCollide(this.CollisionPoints[4]) ||
                allPlatforms.IfCollide(this.CollisionPoints[5]))
            {
                if (this.Velocity.X < 0) this.Velocity = new Vector2(0, this.Velocity.Y);
            }

            if (allPlatforms.IfCollide(this.CollisionPoints[2]) ||
                allPlatforms.IfCollide(this.CollisionPoints[3]))
            {
                if (this.Velocity.Y > 0) this.Velocity = new Vector2(this.Velocity.X, 0);
            }
            else if (allPlatforms.IfCollide(this.CollisionPoints[6]) ||
                allPlatforms.IfCollide(this.CollisionPoints[7]))
            {
                if (this.Velocity.Y < 0) this.Velocity = new Vector2(this.Velocity.X, 0);
            }
        }
    }
}
