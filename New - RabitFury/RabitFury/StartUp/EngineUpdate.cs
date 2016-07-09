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
    }
}
