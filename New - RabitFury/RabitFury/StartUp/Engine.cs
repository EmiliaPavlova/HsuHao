namespace RabitFury.StartUp
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Classes;
    using Classes.Menu;
    using Enums;
    using Classes.Wrappers;
    public partial class Engine : Game
    {
        private const float JumpPower = 0.010f;
        private const float Gravity = 0.0002f;
        private const float MaxVelocity = 0.004f;

        private static Vector2 Resolution = new Vector2(1024, 700);

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

        private GameStateType currentGameState = GameStateType.InGame;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private KeyboardState oldKeyState;

        ////---Menu Items////
        private MenuButton resumeBtn;
        private MenuButton optionsBtn;
        private MenuButton exitBtn;
        ////Menu Items---////

        private Player thePlayer;

        private Texture2D backgroundOverlay;
        private Texture2D pauseBackground;
        private Texture2D defaultTexture;
        private Texture2D playerTexture;
        private Texture2D testPointTexture;
        private Texture2D testBackground;
        private Texture2D brickTexture;
        private Texture2D[] terrain;
        private Texture2D[] collectableTextures;
        private Texture2D[] enemyTextures;

        private AllPlatforms allPlatforms;
        private AllCollectables allCollectables;
        private AllEnemies allEnemies;

        public Engine()
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
            ////---Menu Items////
            resumeBtn = ButtonUtilities.GenerateButton(Content, new Vector2(0.454f * graphics.PreferredBackBufferWidth, 0.28f * graphics.PreferredBackBufferHeight));
            optionsBtn = ButtonUtilities.GenerateButton(Content, new Vector2(0.454f * graphics.PreferredBackBufferWidth, 0.43f * graphics.PreferredBackBufferHeight));
            exitBtn = ButtonUtilities.GenerateButton(Content, new Vector2(0.454f * graphics.PreferredBackBufferWidth, 0.58f * graphics.PreferredBackBufferHeight));
            ////Menu Items---////

            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ButtonUtilities.Load(Content);

            pauseBackground = Content.Load<Texture2D>("GUI/Menu_BG");
            backgroundOverlay = Content.Load<Texture2D>("GUI/BG_Blur");

            defaultTexture = Content.Load<Texture2D>("Textures/TestRect");
            testPointTexture = Content.Load<Texture2D>("Textures/TestPoint");
            playerTexture = Content.Load<Texture2D>("Spritesheets/RealBunnies");

            testBackground = Content.Load<Texture2D>("Textures/TheBG");

            brickTexture = Content.Load<Texture2D>("Textures/Brick");

            terrain = new Texture2D[19];
            for (int i = 0; i < terrain.Length; i++)
            {
                terrain[i] = Content.Load<Texture2D>($"Textures/{i + 1}");
            }

            collectableTextures = new Texture2D[3];
            collectableTextures[0] = Content.Load<Texture2D>("Collectables/carrot");
            collectableTextures[1] = Content.Load<Texture2D>("Collectables/lettuce");
            collectableTextures[2] = Content.Load<Texture2D>("Collectables/coin");

            enemyTextures = new Texture2D[1];
            enemyTextures[0] = Content.Load<Texture2D>("Spritesheets/JustNinja");

            allPlatforms = new AllPlatforms(terrain);
            allCollectables = new AllCollectables(collectableTextures);
            allEnemies = new AllEnemies(enemyTextures);

            // Player set with size { X,Y} // aspect ratio is 3:5 //
            thePlayer = new Player(new Vector2(0.5f, 0.4f), new Vector2(0.045f, 0.075f), new Vector2(0, 0),Color.White,defaultTexture);
            thePlayer.DefaktoSize = new Vector2(190,175);
        }

        protected override void UnloadContent() { }
    }
}