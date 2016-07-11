namespace RabitFury.StartUp
{
    using Classes.Menu;
    using Enums;
    using Exceptions;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

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
                IsMouseVisible = true;

                MenuNavigation.Navigate(keyState, oldKeyState);
                MenuNavigation.Update(ref currentGameState, resumeBtn, optionsBtn, exitBtn);
            }
            else if (currentGameState == GameStateType.InGame)
            {
                IsMouseVisible = false;
                for (int i = 0; i < 2; i++)
                {
                    // Platform Collision //

                    thePlayer.InteractWithWorld(allPlatforms, allCollectables, keyState, new float[] { JumpPower, Gravity, MaxVelocity });

                    for (int j = 0; j < backgrounds.Length; j++)
                    {
                        backgrounds[j] -= thePlayer.Velocity;
                    }

                    allPlatforms.Scroll(-thePlayer.Velocity);
                    allCollectables.Scroll(-thePlayer.Velocity);
                    allEnemies.Scroll(-thePlayer.Velocity);

                    if (allPlatforms.HasBurned == true)
                    {
                        currentGameState = GameStateType.Defeat;
                        throw new EndGameException("Zaeka uide u lavata");
                    }
                }
            }
            else if (currentGameState == GameStateType.Victory)
            {
                //TODO:
            }
            else if (currentGameState == GameStateType.Defeat)
            {
                //TODO:
            }
            else if (currentGameState == GameStateType.Quit)
            {
                Exit();
            }

            oldKeyState = keyState;

            base.Update(gameTime);
        }
    }
}
