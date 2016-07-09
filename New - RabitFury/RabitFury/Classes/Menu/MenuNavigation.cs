namespace RabitFury.Classes.Menu
{
    using Microsoft.Xna.Framework.Input;

    using Constants;
    using Extensions;
    using Enums;

    public static class MenuNavigation
    {
        private static int btnCounter;
        private static int hoveredBtn;

        static MenuNavigation()
        {
            btnCounter = MenuConstants.InitialButtonCounter;
            hoveredBtn = MenuConstants.InitialSelectedButton;
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
        }

        public static void UpdateButtons(params MenuButton[] menuButtons)
        {
            foreach (var menuBtn in menuButtons)
            {
                menuBtn.ButtonState = ButtonStateType.Normal;
            }

            hoveredBtn = MathExtensions.Module(btnCounter, menuButtons.Length);
            menuButtons[hoveredBtn].ButtonState = ButtonStateType.Hovered;

            foreach (var menuBtn in menuButtons)
            {
                if (menuBtn.ButtonState != ButtonStateType.Hovered)
                {
                    menuBtn.ButtonState = ButtonStateType.Normal;
                }
            }
        }

        public static void Reset()
        {
            btnCounter = MenuConstants.InitialButtonCounter;
            hoveredBtn = MenuConstants.InitialSelectedButton;
        }
    }
}
