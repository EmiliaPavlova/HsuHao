using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyTest
{
    public class Game1 : Game
    {
        public const float MAX_SPEED = 0.0050f;
        const float GRAVITY = 0.00010f;

        SoundEffect bgEffect;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D background;

        Player playera;
        Texture2D playerHP;
        Texture2D[,] playerTextures;
        SpriteEffects playerFlip = SpriteEffects.None;
        int currentPlayerAction;

        Coin coin = new Coin();
        Texture2D[] coinTexture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 544;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            playera = new Player(new Vector2(0.1f, 0.45f), new Vector2(0.1f, 0.10f));
            playerTextures = new Texture2D[2, 10];
            currentPlayerAction = 0;

            coinTexture = new Texture2D[6];

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            try
            {
                bgEffect = Content.Load<SoundEffect>("BGSound");
                bgEffect.Play();
            }
            catch (System.Exception)
            {
                
            }

            background = Content.Load<Texture2D>("BGHHD");

            #region playerTextures
            for (int i = 0; i < 10; i++)
            {
                playerTextures[0, i] = Content.Load<Texture2D>($"Idle/Idle{i + 1}");
            }

            for (int i = 0; i < 10; i++)
            {
                playerTextures[1,i] = Content.Load<Texture2D>($"Run/Run{i + 1}");
            }
            #endregion

            playerHP = Content.Load<Texture2D>("HP");

            for (int i = 0; i < 6; i++)
            {
                coinTexture[i] = Content.Load<Texture2D>($"Coin/coin{i + 1}");
            }
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.LeftControl) && keyState.IsKeyDown(Keys.F)
                && graphics.PreferredBackBufferWidth == 960 && graphics.PreferredBackBufferHeight == 544)
            {
                graphics.PreferredBackBufferWidth = 1920;
                graphics.PreferredBackBufferHeight = 1080;
                graphics.IsFullScreen = true;
                background = Content.Load<Texture2D>("BGHD");
                graphics.ApplyChanges();
            }

            else if (keyState.IsKeyDown(Keys.LeftControl) && keyState.IsKeyDown(Keys.F)
                && graphics.PreferredBackBufferWidth == 1920 && graphics.PreferredBackBufferHeight == 1080)
            {
                graphics.PreferredBackBufferWidth = 960;
                graphics.PreferredBackBufferHeight = 544;
                graphics.IsFullScreen = false;
                background = Content.Load<Texture2D>("BGHHD");
                graphics.ApplyChanges();
            }

            if (keyState.IsKeyDown(Keys.D))
            {
                currentPlayerAction = 1;
                playerFlip = SpriteEffects.None;
                playera.MoveRight();
                playera.Animate();
            }

            if (keyState.IsKeyDown(Keys.A))
            {
                currentPlayerAction = 1;
                playerFlip = SpriteEffects.FlipHorizontally;
                playera.MoveLeft();
                playera.Animate();
            }

            if (keyState.IsKeyUp(Keys.A) && keyState.IsKeyUp(Keys.D))
            {
                currentPlayerAction = 0;
                playera.Idle();
            }

            if (playera.velocity.X < MAX_SPEED)
            {
                playera.velocity.X += GRAVITY;
            }

            coin.Animate();

            base.Update(gameTime); 
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(background, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

            spriteBatch.Draw(playerTextures[currentPlayerAction, playera.GetFrame], playera.position * graphics.PreferredBackBufferWidth, null, 
                Color.White, 0f, new Vector2(293, 353.5f),(playera.size * graphics.PreferredBackBufferWidth) / playerTextures[1,0].Width, playerFlip, 1f);

            spriteBatch.Draw(playerHP, new Vector2(0,0), null, Color.White, 0, Vector2.Zero, 
                graphics.PreferredBackBufferHeight / playerHP.Width, SpriteEffects.None, 0f);

            spriteBatch.Draw(coinTexture[coin.GetFrame], new Vector2(0.5f, 0.4f) * graphics.PreferredBackBufferWidth, null, Color.White, 0, Vector2.Zero, (0.05f * graphics.PreferredBackBufferWidth) / coinTexture[0].Width, SpriteEffects.None, 0);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
