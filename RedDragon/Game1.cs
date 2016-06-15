using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RedDragon
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        //Draskame malko , sorry//
        float currentFrame = 2;
        Vector2 rabitPos;
        Vector2 morkovPos = new Vector2(250, 420);
        Vector2 rabitSpeed = new Vector2(2, 2);
        Texture2D rabitRun;
        Texture2D morkova;

        SpriteEffects flipped = SpriteEffects.None;
        Texture2D BG;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 540;
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            rabitPos = new Vector2(400, 200);
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            rabitRun = Content.Load<Texture2D>("SpriteSheets/RunningSpritesheet");
            BG = Content.Load<Texture2D>("Images/BG2");
            morkova = Content.Load<Texture2D>("Images/morkov");
        }
        
        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyState = Keyboard.GetState();

            bool isMoving = false;

            if (keyState.IsKeyDown(Keys.Right))
            {
                rabitPos.X += rabitSpeed.X; isMoving = true;flipped = SpriteEffects.None;
            }
            if (keyState.IsKeyDown(Keys.Left))
            {
                rabitPos.X -= rabitSpeed.X; isMoving = true;flipped = SpriteEffects.FlipHorizontally;
            }
            if (keyState.IsKeyDown(Keys.Down))
            {
                rabitPos.Y += rabitSpeed.Y; isMoving = true;
            }
            if (keyState.IsKeyDown(Keys.Up))
            {
                rabitPos.Y -= rabitSpeed.Y; isMoving = true;
            }
            if (isMoving) Animate(); else Stop();

            if (Vector2.Distance(morkovPos,rabitPos) < 100)
            {
                morkovPos += ((morkovPos - rabitPos) / Vector2.Distance(morkovPos, rabitPos))*rabitSpeed.X;
            }

            base.Update(gameTime);
        }

        void Animate()
        {
            currentFrame += 0.18f;
            if (currentFrame > 5.8f) Stop();
        }
        void Stop()
        {
            currentFrame = 2;
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();

            spriteBatch.Draw(BG, new Vector2(0,-200), Color.White);
            spriteBatch.Draw(morkova, morkovPos, null, Color.White, 0f, new Vector2(16, 16), 0.25f, SpriteEffects.None, 1f);



            spriteBatch.Draw(rabitRun, rabitPos, new Rectangle(((int)currentFrame) * 44, 0, 44, 43), Color.White, 0f, new Vector2(22, 22), 1f, flipped, 1f);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
