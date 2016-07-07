namespace RabitFury
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Classes;
    using Classes.GameObject;
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static Vector2 Resolution = new Vector2(960,544);
        Texture2D defaultTexture;
        Texture2D testPointTexture;
        Texture2D testBackground;
        Texture2D brickTexture;
        Texture2D[] terrain;
        Vector2 bgSize = new Vector2(1, 0.5625f);
        Vector2 bgPos = new Vector2(0.5f, 0.28125f);
        Vector2 bgPos2 = new Vector2(1.5f, 0.28125f);
        Vector2 velocity = new Vector2(0, 0);
        AllPlatforms allPlatforms;

        Player thePlayer;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = (int)Resolution.X;
            graphics.PreferredBackBufferHeight = (int)Resolution.Y;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }
        
        protected override void Initialize()
        {
            thePlayer = new Player(new Vector2(0.045f,0.075f)); //Player set with size {X,Y} // aspect ratio is 3:5 //
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            //Load with textures//
            spriteBatch = new SpriteBatch(GraphicsDevice);
            defaultTexture = Content.Load<Texture2D>("Textures/TestRect");
            testPointTexture = Content.Load<Texture2D>("Textures/TestPoint");
            testBackground = Content.Load<Texture2D>("Textures/TheBG");
            brickTexture = Content.Load<Texture2D>("Textures/Brick");
            terrain = new Texture2D[18];
            for (int i = 0; i < terrain.Length; i++)
            {
                terrain[i] = Content.Load<Texture2D>($"Textures/{i + 1}");
            }
            //Initialize//
            allPlatforms = new AllPlatforms(terrain);
        }
        
        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyState = Keyboard.GetState();

            velocity.X = 0;
            velocity.Y += 0.00005f;

            if (keyState.IsKeyDown(Keys.Right))
            {
                velocity.X = 0.003f;
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                velocity.X = -0.003f;
            }
            if (keyState.IsKeyDown(Keys.Down))
            {
                velocity.Y = 0.003f;
            }
            else if (keyState.IsKeyDown(Keys.Up) && (allPlatforms.IfCollide(thePlayer.CollisionPoints[2]) || allPlatforms.IfCollide(thePlayer.CollisionPoints[3])))
            {
                velocity.Y = -0.005f;
            }

            // Platform Collision //
            if (allPlatforms.IfCollide(thePlayer.CollisionPoints[0]) || allPlatforms.IfCollide(thePlayer.CollisionPoints[1]))
            {
                if (velocity.X > 0) velocity.X = 0;
            }
            else if (allPlatforms.IfCollide(thePlayer.CollisionPoints[4]) || allPlatforms.IfCollide(thePlayer.CollisionPoints[5]))
            {
                if (velocity.X < 0) velocity.X = 0;
            }
            if (allPlatforms.IfCollide(thePlayer.CollisionPoints[2]) || allPlatforms.IfCollide(thePlayer.CollisionPoints[3]))
            {
                if (velocity.Y > 0) velocity.Y = 0;
            }
            else if (allPlatforms.IfCollide(thePlayer.CollisionPoints[6]) || allPlatforms.IfCollide(thePlayer.CollisionPoints[7]))
            {
                if (velocity.Y < 0) velocity.Y = 0;
            }
            


            bgPos -= velocity;
            bgPos2 -= velocity;
            allPlatforms.Scroll(-velocity);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.FrontToBack);

            //Background :

            spriteBatch.Draw(
                testBackground,
                bgPos * Resolution.X,
                null,
                Color.White,
                0f,
                new Vector2(testBackground.Width / 2,
                testBackground.Height / 2),
                (bgSize.X*Resolution.X)/testBackground.Width,
                SpriteEffects.None,
                1f);

            spriteBatch.Draw(testBackground, bgPos2 * Resolution.X, null, Color.White, 0f, new Vector2(testBackground.Width / 2, testBackground.Height / 2), (bgSize.X * Resolution.X) / testBackground.Width, SpriteEffects.None, 1f);


            //The platform is being drawn :
            //spriteBatch.Draw(theBrick.TheTexture, theBrick.Position * Resolution.X, null, theBrick.TheColor, 0f, new Vector2(theBrick.TheTexture.Width / 2, theBrick.TheTexture.Height / 2), (theBrick.Size.X * Resolution.X) / theBrick.TheTexture.Width, SpriteEffects.None, 1f);
            foreach (Platform p in allPlatforms.rocks)
            {
                spriteBatch.Draw(p.TheTexture, p.Position * Resolution.X, null, p.TheColor, 0f, new Vector2(p.TheTexture.Width / 2, p.TheTexture.Height / 2), (p.Size.X * Resolution.X) / p.TheTexture.Width, SpriteEffects.None, 1f);
            }


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
