namespace RabitFury.StartUp
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    using Enums;
    using Classes.Menu;
    public partial class Engine
    {
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
                    MenuNavigation.Reset();
                    currentGameState = GameStateType.Pause;
                }
                else if (currentGameState == GameStateType.Pause)
                {
                    currentGameState = GameStateType.InGame;
                }
            }

            if (currentGameState == GameStateType.MainMenu)
            {
                ////TODO
            }
            else if (currentGameState == GameStateType.Pause)
            {
                MenuNavigation.Navigate(keyState, oldKeyState);
            }
            else if (currentGameState == GameStateType.InGame)
            {
                for (int i = 0; i < 2; i++)
                {
                    thePlayer.Velocity = new Vector2(0, thePlayer.Velocity.Y);
                    if (thePlayer.Velocity.Y < MaxVelocity)
                    {
                        thePlayer.Velocity = new Vector2(thePlayer.Velocity.X, thePlayer.Velocity.Y + Gravity);
                    }

                    if (keyState.IsKeyDown(Keys.Right))
                    {
                        thePlayer.Velocity = new Vector2(0.003f, thePlayer.Velocity.Y);
                    }

                    if (keyState.IsKeyDown(Keys.Left))
                    {
                        thePlayer.Velocity = new Vector2(-0.003f, thePlayer.Velocity.Y);
                    }

                    if (keyState.IsKeyDown(Keys.Up) &&
                        !oldKeyState.IsKeyDown(Keys.Up) &&
                        (allPlatforms.IfCollide(thePlayer.CollisionPoints[2]) ||
                        allPlatforms.IfCollide(thePlayer.CollisionPoints[3])))
                    {
                        thePlayer.Velocity = new Vector2(thePlayer.Velocity.X, -JumpPower);
                    }

                    // Platform Collision //

                    thePlayer.InteractWithWorld(allPlatforms);

                    for (int j = 0; j < backgrounds.Length; j++)
                    {
                        backgrounds[j] -= thePlayer.Velocity;
                    }

                    allPlatforms.Scroll(-thePlayer.Velocity);
                    allCollectables.Scroll(-thePlayer.Velocity);
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
    }
}
