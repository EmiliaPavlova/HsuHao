namespace RabitFury.StartUp
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    using System;
    using Enums;
    using Classes.Menu;
    using Exceptions;

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
                    // Platform Collision //

                    thePlayer.InteractWithWorld(allPlatforms,keyState,new float[] {JumpPower,Gravity,MaxVelocity});

                    for (int j = 0; j < backgrounds.Length; j++)
                    {
                        backgrounds[j] -= thePlayer.Velocity;
                    }

                    allPlatforms.Scroll(-thePlayer.Velocity);
                    allCollectables.Scroll(-thePlayer.Velocity);
                    if(allPlatforms.HasBurned == true)
                    {
                        currentGameState = GameStateType.Defeat;
                        throw new EndGameException("Zaeka uide u lavata");
                    }
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
