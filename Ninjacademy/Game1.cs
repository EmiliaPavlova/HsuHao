using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ninjacademy
{
    public class Game1 : Game
    {
        public const float MAX_SPEED = 0.0050f;
        const float GRAVITY = 0.00010f;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D background;

        Player player1;
        Texture2D player1HP;
        Texture2D[,] player1Textures;
        SpriteEffects player1Flip = SpriteEffects.None;
        int player1Action;

        Player player2;
        Texture2D player2HP;
        Texture2D[,] player2Textures;
        SpriteEffects player2Flip = SpriteEffects.FlipHorizontally;
        int player2Action;

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
            player1 = new Player(new Vector2(0.1f, 0.465f), new Vector2(0.1f, 0.10f));
            player1Textures = new Texture2D[2, 10];
            player1Action = 0;

            player2 = new Player(new Vector2(0.95f, 0.45f), new Vector2(0.1f, 0.10f));
            player2Textures = new Texture2D[2, 10];
            player2Action = 0;

            coinTexture = new Texture2D[6];

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("BGHHD");

            #region player1TexturesLoad
            for (int i = 0; i < 10; i++)
            {
                player1Textures[0, i] = Content.Load<Texture2D>($"1Idle/1Idle{i + 1}");
            }

            for (int i = 0; i < 10; i++)
            {
                player1Textures[1,i] = Content.Load<Texture2D>($"1Run/1Run{i + 1}");
            }

            player1HP = Content.Load<Texture2D>("1HP");
            #endregion

            #region player2TexturesLoad
            for (int i = 0; i < 10; i++)
            {
                player2Textures[0, i] = Content.Load<Texture2D>($"2Idle/2Idle{i + 1}");
            }

            for (int i = 0; i < 10; i++)
            {
                player2Textures[1, i] = Content.Load<Texture2D>($"2Run/2Run{i + 1}");
            }

            player2HP = Content.Load<Texture2D>("2HP");
            #endregion

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

            #region ScreenSizeSettings
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
            #endregion

            #region Player1
            if (keyState.IsKeyDown(Keys.D))
            {
                player1Action = 1;
                player1Flip = SpriteEffects.None;
                player1.MoveRight();
                player1.Animate();
            }

            if (keyState.IsKeyDown(Keys.A))
            {
                player1Action = 1;
                player1Flip = SpriteEffects.FlipHorizontally;
                player1.MoveLeft();
                player1.Animate();
            }

            if (keyState.IsKeyUp(Keys.A) && keyState.IsKeyUp(Keys.D))
            {
                player1Action = 0;
                player1.Idle();
            }

            if (player1.velocity.X < MAX_SPEED)
            {
                player1.velocity.X += GRAVITY;
            }
            #endregion

            #region Player2
            if (keyState.IsKeyDown(Keys.Right))
            {
                player2Action = 1;
                player2Flip = SpriteEffects.None;
                player2.MoveRight();
                player2.Animate();
            }

            if (keyState.IsKeyDown(Keys.Left))
            {
                player2Action = 1;
                player2Flip = SpriteEffects.FlipHorizontally;
                player2.MoveLeft();
                player2.Animate();
            }

            if (keyState.IsKeyUp(Keys.Left) && keyState.IsKeyUp(Keys.Right))
            {
                player2Action = 0;
                player2.Idle();
            }

            if (player2.velocity.X < MAX_SPEED)
            {
                player2.velocity.X += GRAVITY;
            }

            #endregion

            coin.Animate();

            base.Update(gameTime); 
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(background, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

            spriteBatch.Draw(player1Textures[player1Action, player1.GetFrame], player1.position * graphics.PreferredBackBufferWidth, null, 
                Color.White, 0f, new Vector2(293, 353.5f),(player1.size * graphics.PreferredBackBufferWidth) / player1Textures[1,0].Width, player1Flip, 1f);

            spriteBatch.Draw(player1HP, new Vector2(0,0) * graphics.PreferredBackBufferWidth, null, Color.White, 0, Vector2.Zero, 
                graphics.PreferredBackBufferHeight / player1HP.Width, SpriteEffects.None, 0f);

            spriteBatch.Draw(player2HP, new Vector2(0.607f, 0) * graphics.PreferredBackBufferWidth, null, Color.White, 0, Vector2.Zero,
                graphics.PreferredBackBufferHeight / player2HP.Width, SpriteEffects.None, 0f);

            spriteBatch.Draw(player2Textures[player2Action, player2.GetFrame], player2.position * graphics.PreferredBackBufferWidth, null,
                Color.White, 0f, new Vector2(293, 353.5f), (player2.size * graphics.PreferredBackBufferWidth) / player2Textures[1, 0].Width, player2Flip, 1f);

            spriteBatch.Draw(coinTexture[coin.GetFrame], new Vector2(0.5f, 0.4f) * graphics.PreferredBackBufferWidth, null, 
                Color.White, 0, Vector2.Zero, (0.05f * graphics.PreferredBackBufferWidth) / coinTexture[0].Width, SpriteEffects.None, 0);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
