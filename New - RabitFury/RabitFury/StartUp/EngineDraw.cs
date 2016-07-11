namespace RabitFury.StartUp
{
    using Classes.GameObject;
    using Classes.Menu;
    using Enums;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class Engine
    {
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(221, 248, 255));

            spriteBatch.Begin(SpriteSortMode.FrontToBack);

            if (currentGameState == GameStateType.Intro)
            {
                //Draw intro BG
                spriteBatch.Draw(
                    introBackground,
                    Vector2.Zero,
                    null,
                    Color.White,
                    0f,
                    Vector2.Zero,
                    1f,
                    SpriteEffects.None,
                    1.0f);
            }

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
            for (int i = 0; i < allBackgroundObjects.DynamicBackgroundObjects.Count; i++)
            {
                spriteBatch.Draw(
                allBackgroundObjects.DynamicBackgroundObjects[i].TheTexture,
                allBackgroundObjects.DynamicBackgroundObjects[i].Position * Resolution.X,
                null,
                Color.White,
                0f,
                new Vector2(allBackgroundObjects.DynamicBackgroundObjects[i].TheTexture.Width / 2,
                allBackgroundObjects.DynamicBackgroundObjects[i].TheTexture.Height / 2),
                (allBackgroundObjects.DynamicBackgroundObjects[i].Size.X * Resolution.X) / allBackgroundObjects.DynamicBackgroundObjects[i].TheTexture.Width,
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
                (thePlayer.Size.X * Resolution.X) / defaultTexture.Width * 0.9f, //Magic number 0.9 to fix size issues :)
                thePlayer.IsFlipped,
                0.1f);

            ////players' collision points being drawn , they will always be 8
            //for (int i = 0; i < theplayer.collisionpoints.length; i++)
            //{
            //    spritebatch.draw(
            //        testpointtexture,
            //        theplayer.collisionpoints[i] * resolution.x,
            //        null,
            //        color.red,
            //        0f,
            //        new vector2(2, 2),
            //        1f,
            //        spriteeffects.none,
            //        0.1f);
            //}

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

            //Enemies being drawn
            foreach (Enemy p in allEnemies.ListEnemies)
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


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
