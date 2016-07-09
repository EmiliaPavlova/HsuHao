namespace RabitFury.StartUp
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Classes;
    using Classes.GameObject;
    using Classes.Menu;
    using Enums;

    public partial class Engine
    {
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(221, 248, 255));

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
                playerTexture,
                thePlayer.Position * Resolution.X,
                thePlayer.GetRectangle,
                thePlayer.TheColor,
                0f,
                new Vector2(thePlayer.DefaktoSize.X / 2,
                thePlayer.DefaktoSize.X / 2),
                (thePlayer.Size.X * Resolution.X) / defaultTexture.Width,
                thePlayer.IsFlipped,
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
