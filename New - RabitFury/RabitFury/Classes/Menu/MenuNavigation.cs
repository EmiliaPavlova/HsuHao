namespace RabitFury.Classes.Menu
{
    using Microsoft.Xna.Framework.Input;

    using Constants;
    using Extensions;
    using Enums;

    public static class MenuNavigation
    {
        private static int btnCounter;
        private static int selectedBtn;
        private static ButtonStateType buttonState;

        static MenuNavigation()
        {
            btnCounter = MenuConstants.InitialButtonCounter;
            selectedBtn = MenuConstants.InitialSelectedButton;
            buttonState = ButtonStateType.Hovered;
        }

        public static void Navigate(KeyboardState keyState, KeyboardState oldKeyState)
        {
            if (keyState.IsKeyDown(Keys.Down) && !oldKeyState.IsKeyDown(Keys.Down))
            {
                btnCounter++;
            }
            else if (keyState.IsKeyDown(Keys.Up) && !oldKeyState.IsKeyDown(Keys.Up))
            {
                btnCounter--;
            }
            else if (keyState.IsKeyDown(Keys.Enter) && !oldKeyState.IsKeyDown(Keys.Enter))
            {
                buttonState = ButtonStateType.Clicked;
            }
        }

        public static void Update(ref GameStateType gameState, params MenuButton[] menuButtons)
        {
            foreach (var menuBtn in menuButtons)
            {
                menuBtn.ButtonState = ButtonStateType.Normal;
            }

            selectedBtn = MathExtensions.Module(btnCounter, menuButtons.Length);

            if (buttonState == ButtonStateType.Hovered)
            {
                menuButtons[selectedBtn].ButtonState = ButtonStateType.Hovered;
            }
            else if (buttonState == ButtonStateType.Clicked)
            {
                menuButtons[selectedBtn].ButtonState = ButtonStateType.Clicked;
            }

            foreach (var menuBtn in menuButtons)
            {
                if (menuBtn.ButtonState != buttonState)
                {
                    menuBtn.ButtonState = ButtonStateType.Normal;
                }
            }

            if (buttonState == ButtonStateType.Clicked)
            {
                ButtonAction(ref gameState, menuButtons[selectedBtn].ButtonAction);
                Reset();
            }
        }

        private static void ButtonAction(ref GameStateType gameState, ButtonActionType buttonAction)
        {
            if (buttonAction == ButtonActionType.Resume)
            {
                gameState = GameStateType.InGame;
            }
            else if (buttonAction == ButtonActionType.Options)
            {
                ////TODO
            }
            else if (buttonAction == ButtonActionType.Quit)
            {
                gameState = GameStateType.Quit;
            }
        }

        public static void Reset()
        {
            btnCounter = MenuConstants.InitialButtonCounter;
            selectedBtn = MenuConstants.InitialSelectedButton;
            buttonState = ButtonStateType.Hovered;
        }
    }
}
