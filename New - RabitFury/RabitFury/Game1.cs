namespace RabitFury
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Classes;
    using Classes.GameObject;
    using Classes.Menu;
    using Enums;

    public class Game1 : Game
    {
        private const float JumpPower = 0.010f;
        private const float Gravity = 0.0002f;
        private const float MaxVelocity = 0.004f;

        MenuButton resumeBtn;
        MenuButton optionsBtn;
        MenuButton exitBtn;

        public static Vector2 Resolution = new Vector2(1024, 700);

        private GameStateType currentGameState = GameStateType.InGame;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private KeyboardState oldKeyState;

        private Texture2D backgroundOverlay;
        private Texture2D pauseBackground;
        private Texture2D defaultTexture;
        private Texture2D testPointTexture;
        private Texture2D testBackground;
        private Texture2D brickTexture;
        private Texture2D[] terrain;
        private Texture2D[] collectableTextures;

        private Vector2 bgSize = new Vector2(1, 0.5625f);
        private Vector2[] backgrounds = new Vector2[7]
        {
            new Vector2(0.445f, 0.28125f),
            new Vector2(1.445f, 0.28125f),
            new Vector2(2.445f, 0.28125f),
            new Vector2(3.445f, 0.28125f),
            new Vector2(4.445f, 0.28125f),
            new Vector2(5.445f, 0.28125f),
            new Vector2(6.445f, 0.28125f)
        };

        private Vector2 velocity = new Vector2(0, 0);

        private AllPlatforms allPlatforms;

        private AllCollectables allCollectables;

        private Player thePlayer;

        public GraphicsDeviceManager GetGraphics
        {
            get
            {
                return this.graphics;
            }
        }

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
            // Player set with size { X,Y} // aspect ratio is 3:5 //
            resumeBtn = ButtonUtilities.GenerateButton(Content, new Vector2(0.454f * graphics.PreferredBackBufferWidth, 0.28f * graphics.PreferredBackBufferHeight));
            optionsBtn = ButtonUtilities.GenerateButton(Content, new Vector2(0.454f * graphics.PreferredBackBufferWidth, 0.43f * graphics.PreferredBackBufferHeight));
            exitBtn = ButtonUtilities.GenerateButton(Content, new Vector2(0.454f * graphics.PreferredBackBufferWidth, 0.58f * graphics.PreferredBackBufferHeight));

            thePlayer = new Player(new Vector2(0.045f, 0.075f));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Load with textures//
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ButtonUtilities.Load(Content);

            pauseBackground = Content.Load<Texture2D>("GUI/Menu_BG");
            backgroundOverlay = Content.Load<Texture2D>("GUI/BG_Blur");

            defaultTexture = Content.Load<Texture2D>("Textures/TestRect");
            testPointTexture = Content.Load<Texture2D>("Textures/TestPoint");

            testBackground = Content.Load<Texture2D>("Textures/TheBG");

            brickTexture = Content.Load<Texture2D>("Textures/Brick");

            terrain = new Texture2D[19];
            for (int i = 0; i < terrain.Length; i++)
            {
                terrain[i] = Content.Load<Texture2D>($"Textures/{i + 1}");
            }
            collectableTextures = new Texture2D[2];
            collectableTextures[0] = Content.Load<Texture2D>("Collectables/carrot");
            collectableTextures[1] = Content.Load<Texture2D>("Collectables/lettuce");


            //Initialize//
            allPlatforms = new AllPlatforms(terrain);
            allCollectables = new AllCollectables(collectableTextures);
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.P) && !oldKeyState.IsKeyDown(Keys.P))
            {
                resumeBtn.ButtonState = ButtonStateType.Hovered; ////TODO

                if (currentGameState == GameStateType.InGame)
                {
                    currentGameState = GameStateType.Pause;
                }
                else if (currentGameState == GameStateType.Pause)
                {
                    currentGameState = GameStateType.InGame;
                }
            }
            else if (currentGameState == GameStateType.MainMenu)
            {
                ////TODO
            }
            else if (currentGameState == GameStateType.Pause)
            {
                ////TODO
            }
            else if (currentGameState == GameStateType.InGame)
            {
                for (int i = 0; i < 2; i++)
                {
                    velocity.X = 0;
                    if (velocity.Y < MaxVelocity)
                    {
                        velocity.Y += Gravity;
                    }

                    if (keyState.IsKeyDown(Keys.Right))
                    {
                        velocity.X = 0.003f;
                    }

                    if (keyState.IsKeyDown(Keys.Left))
                    {
                        velocity.X = -0.003f;
                    }

                    if (keyState.IsKeyDown(Keys.Up) &&
                        !oldKeyState.IsKeyDown(Keys.Up) &&
                        (allPlatforms.IfCollide(thePlayer.CollisionPoints[2]) ||
                        allPlatforms.IfCollide(thePlayer.CollisionPoints[3])))
                    {
                        velocity.Y = -JumpPower;
                    }

                    // Platform Collision //
                    if (allPlatforms.IfCollide(thePlayer.CollisionPoints[0]) ||
                        allPlatforms.IfCollide(thePlayer.CollisionPoints[1]))
                    {
                        if (velocity.X > 0) velocity.X = 0;
                    }
                    else if (allPlatforms.IfCollide(thePlayer.CollisionPoints[4]) ||
                        allPlatforms.IfCollide(thePlayer.CollisionPoints[5]))
                    {
                        if (velocity.X < 0) velocity.X = 0;
                    }
                    if (allPlatforms.IfCollide(thePlayer.CollisionPoints[2]) ||
                        allPlatforms.IfCollide(thePlayer.CollisionPoints[3]))
                    {
                        if (velocity.Y > 0) velocity.Y = 0;
                    }
                    else if (allPlatforms.IfCollide(thePlayer.CollisionPoints[6]) ||
                        allPlatforms.IfCollide(thePlayer.CollisionPoints[7]))
                    {
                        if (velocity.Y < 0) velocity.Y = 0;
                    }

                    for (int j = 0; j < backgrounds.Length; j++)
                    {
                        backgrounds[j] -= velocity;
                    }

                    allPlatforms.Scroll(-velocity);
                    allCollectables.Scroll(-velocity);
                }
            }
            else if (currentGameState == GameStateType.Victory)
            {
                ////TODO
            }
            else if (currentGameState == GameStateType.Defeat)
            {
                ////TODO
            }

            oldKeyState = keyState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(216, 251, 248));

            spriteBatch.Begin(SpriteSortMode.FrontToBack);

            if (currentGameState == GameStateType.Pause)
            {
                ButtonUtilities.Draw(resumeBtn, spriteBatch, (int)resumeBtn.ButtonState);
                ButtonUtilities.Draw(optionsBtn, spriteBatch, (int)optionsBtn.ButtonState);
                ButtonUtilities.Draw(exitBtn, spriteBatch, (int)exitBtn.ButtonState);

                spriteBatch.Draw(
                    pauseBackground,
                    new Vector2(
                    0.365f * graphics.PreferredBackBufferWidth,
                    0.15f * graphics.PreferredBackBufferHeight),
                    null,
                    Color.White,
                    0f,
                    Vector2.Zero,
                    0.6f,
                    SpriteEffects.None,
                    0.9f);

                spriteBatch.Draw(
                    backgroundOverlay,
                    Vector2.Zero,
                    null,
                    Color.White * 0.8f,
                    0f,
                    Vector2.Zero,
                    1f,
                    SpriteEffects.None,
                    0.9f);
            }

            //Background is being drawn here: 
            foreach (var background in backgrounds)
            {
                spriteBatch.Draw(
                testBackground,
                background * Resolution.X,
                null,
                Color.White,
                0f,
                new Vector2(testBackground.Width / 2,
                testBackground.Height / 2),
                (bgSize.X * Resolution.X) / testBackground.Width,
                SpriteEffects.None,
                0f);
            }

            //The platform is being drawn
            foreach (Platform p in allPlatforms.Rocks)
            {
                if (p.TheTexture != null)
                {
                    spriteBatch.Draw(
                        p.TheTexture,
                        p.Position * Resolution.X,
                        null,
                        p.TheColor,
                        0f,
                        new Vector2(p.TheTexture.Width / 2, p.TheTexture.Height / 2),
                        (p.Size.X * Resolution.X) / p.TheTexture.Width,
                        SpriteEffects.None,
                        0.1f);
                }
            }

            //Player being drawn
            spriteBatch.Draw(
                defaultTexture,
                Player.Position * Resolution.X,
                null,
                new Color(105, 110, 255),
                0f,
                new Vector2(defaultTexture.Width / 2,
                defaultTexture.Height / 2),
                (thePlayer.Size.X * Resolution.X) / defaultTexture.Width,
                SpriteEffects.None,
                0.1f);

            //Players' collision points being drawn , they will always be 8
            for (int i = 0; i < thePlayer.CollisionPoints.Length; i++)
            {
                spriteBatch.Draw(
                    testPointTexture,
                    thePlayer.CollisionPoints[i] * Resolution.X,
                    null,
                    Color.Red,
                    0f,
                    new Vector2(2, 2),
                    1f,
                    SpriteEffects.None,
                    0.1f);
            }

            foreach (Collectable c in allCollectables.collectables)
            {
                if (c.TheTexture != null)
                {
                    spriteBatch.Draw(
                    c.TheTexture,
                    c.Position * Resolution.X,
                    null,
                    c.TheColor,
                    0f,
                    new Vector2(c.TheTexture.Width / 2,
                    c.TheTexture.Height / 2),
                    (c.Size.X * Resolution.X) / c.TheTexture.Width,
                    SpriteEffects.None,
                    0.1f);
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
