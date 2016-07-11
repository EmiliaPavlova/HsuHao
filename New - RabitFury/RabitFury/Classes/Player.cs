namespace RabitFury.Classes
{
    using GameObject;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    public class Player : RigidBody, IAnimateable
    {
        public Vector2 EdgeShifts { get; set; }

        public Rectangle ViewRect { get; set; }

        public SpriteEffects IsFlipped { get; set; }

        public Vector2 DefaktoSize { get; set; }

        public float CurrentFrame { get; set; }

        public int Points { get; set; }

        public int GetFrame
        {
            get
            {
                return (int)CurrentFrame;
            }
        }

        public Rectangle GetRectangle
        {
            get
            {
                return new Rectangle(GetFrame * (int)DefaktoSize.X - 5, 0, (int)DefaktoSize.X, (int)DefaktoSize.Y);
            }
        }

        public int ActionIndex { get; set; }



        public Player(Vector2 setPos, Vector2 setSize, Vector2 setVelicty, Color setColor, Texture2D setTexture)
            : base(setPos, setSize, setVelicty, setColor, setTexture)
        {
            EdgeShifts = new Vector2(0.37f, 0.4f);

            Position = setPos;
            Size = setSize;
            Velocity = setVelicty;
            TheColor = setColor;
            TheTexture = setTexture;
            Points = 0;

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

            //Animation stuff set bellow:
            CurrentFrame = 0f;
        }


        public void InteractWithWorld(AllPlatforms allPlatforms, AllCollectables allCollectables, KeyboardState keyState, float[] worldArgs)
        {
            bool touchDown = false;

            this.Velocity = new Vector2(0, this.Velocity.Y);
            if (this.Velocity.Y < worldArgs[2]) //worldArgs[2] is MaxVelocity//
            {
                this.Velocity = new Vector2(this.Velocity.X, this.Velocity.Y + worldArgs[1]); // worldArgs[1] is Gravity//
            }

            if (keyState.IsKeyDown(Keys.Right))
            {
                this.Velocity = new Vector2(0.003f, this.Velocity.Y);
                IsFlipped = SpriteEffects.None;
            }

            if (keyState.IsKeyDown(Keys.Left))
            {
                this.Velocity = new Vector2(-0.003f, this.Velocity.Y);
                IsFlipped = SpriteEffects.FlipHorizontally;
            }

            if (keyState.IsKeyDown(Keys.Up) && this.Velocity.Y >= 0 &&
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
                touchDown = true;
            }
            else if (allPlatforms.IfCollide(this.CollisionPoints[6]) ||
                allPlatforms.IfCollide(this.CollisionPoints[7]))
            {
                if (this.Velocity.Y < 0) this.Velocity = new Vector2(this.Velocity.X, 0);
            }

            //Collide with collectables
            allCollectables.Collide(CollisionPoints[0], this); allCollectables.Collide(CollisionPoints[1], this);
            allCollectables.Collide(CollisionPoints[2], this); allCollectables.Collide(CollisionPoints[3], this);
            allCollectables.Collide(CollisionPoints[4], this); allCollectables.Collide(CollisionPoints[5], this);
            allCollectables.Collide(CollisionPoints[6], this); allCollectables.Collide(CollisionPoints[7], this);

            //Control Animation:
            if (touchDown && (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.Left)))
            {
                this.Animate();
            }
            else
            {
                this.Reset(touchDown);
            }

        }

        public void Animate()
        {
            CurrentFrame += 0.2f;

            if (CurrentFrame >= 10f)
            {
                CurrentFrame = 0;
            }
        }

        public void Reset(bool touchDown)
        {
            if (touchDown)
            {
                CurrentFrame = 0;
            }
            else
            {
                CurrentFrame = 2;
            }
        }
    }
}
