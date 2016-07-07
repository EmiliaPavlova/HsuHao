using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RabitFury
{
    using Classes;
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static Vector2 Resolution = new Vector2(1094,614);
        Texture2D defaultTexture;
        Texture2D testPointTexture;
        Texture2D testBackground;
        Texture2D brickTexture;
        Vector2 bgSize = new Vector2(1, 0.5625f);
        Vector2 bgPos = new Vector2(0.5f, 0.28125f);
        Vector2 bgPos2 = new Vector2(1.5f, 0.28125f);

        //Rock theBrick; 


        Player thePlayer;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = (int)Resolution.X;
            graphics.PreferredBackBufferHeight = (int)Resolution.Y;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }
        
        protected override void Initialize()
        {
            thePlayer = new Player(new Vector2(0.06f,0.1f)); //Player set with size {X,Y} // aspect ratio is 3:5 //

            //bool[] canMove = yourClass.Collide(thePlayer.CollisionPoints);
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            defaultTexture = Content.Load<Texture2D>("Textures/TestRect");
            testPointTexture = Content.Load<Texture2D>("Textures/TestPoint");
            testBackground = Content.Load<Texture2D>("Textures/TheBG");
            brickTexture = Content.Load<Texture2D>("Textures/Brick");

            //Load with textures//
            //theBrick = new Rock(new Vector2(0.7f, 0.45f), new Vector2(0.08f, 0.08f), Color.White, brickTexture);
        }
        
        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyState = Keyboard.GetState();

            Vector2 currentMove = new Vector2(0, 0);

            if (keyState.IsKeyDown(Keys.Right))
            {
                currentMove.X = 0.001f;
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                currentMove.X = -0.001f;
            }

            if (keyState.IsKeyDown(Keys.Down))
            {
                currentMove.Y = 0.001f;
            }
            else if (keyState.IsKeyDown(Keys.Up))
            {
                currentMove.Y = -0.001f;
            }

            
            /* // Platform Collision //
            if (theBrick.IfCollide(thePlayer.CollisionPoints[0]) || theBrick.IfCollide(thePlayer.CollisionPoints[1]))
            {
                if (currentMove.X > 0) currentMove.X = 0;
            }
            else if (theBrick.IfCollide(thePlayer.CollisionPoints[4]) || theBrick.IfCollide(thePlayer.CollisionPoints[5]))
            {
                if (currentMove.X < 0) currentMove.X = 0;
            }
            if (theBrick.IfCollide(thePlayer.CollisionPoints[2]) || theBrick.IfCollide(thePlayer.CollisionPoints[3]))
            {
                if (currentMove.Y > 0) currentMove.Y = 0;
            }
            else if (theBrick.IfCollide(thePlayer.CollisionPoints[6]) || theBrick.IfCollide(thePlayer.CollisionPoints[7]))
            {
                if (currentMove.Y < 0) currentMove.Y = 0;
            }
            */


            bgPos -= currentMove;
            bgPos2 -= currentMove;
            //theBrick.Scroll(-currentMove);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            //Backgrounda :


            spriteBatch.Draw(testBackground, bgPos * Resolution.X, null, Color.White, 0f, new Vector2(testBackground.Width / 2, testBackground.Height / 2), (bgSize.X*Resolution.X)/testBackground.Width, SpriteEffects.None, 1f);
            spriteBatch.Draw(testBackground, bgPos2 * Resolution.X, null, Color.White, 0f, new Vector2(testBackground.Width / 2, testBackground.Height / 2), (bgSize.X * Resolution.X) / testBackground.Width, SpriteEffects.None, 1f);


            //The platform is being drawn :
            //spriteBatch.Draw(theBrick.TheTexture, theBrick.Position * Resolution.X, null, theBrick.TheColor, 0f, new Vector2(theBrick.TheTexture.Width / 2, theBrick.TheTexture.Height / 2), (theBrick.Size.X * Resolution.X) / theBrick.TheTexture.Width, SpriteEffects.None, 1f);
            // TO DO


            //Player being drawn//
            spriteBatch.Draw(defaultTexture, Player.Position*Resolution.X, null, new Color(105, 110, 255), 0f, new Vector2(defaultTexture.Width / 2, defaultTexture.Height / 2),(thePlayer.Size.X*Resolution.X)/defaultTexture.Width, SpriteEffects.None, 1f);
            

            //Players' collision points being drawn , they will always be 8//
            for (int i = 0;i < thePlayer.CollisionPoints.Length;i++)
            {
                spriteBatch.Draw(testPointTexture, thePlayer.CollisionPoints[i]*Resolution.X, null, Color.Red, 0f, new Vector2(2, 2), 1, SpriteEffects.None, 1f);
            }

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
