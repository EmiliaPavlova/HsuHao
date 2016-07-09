namespace RabitFury.Classes.Menu
{
    using Microsoft.Xna.Framework.Input;
    using StartUp;

    public static class MenuNavigation
    {
        private static int btnCounter;

        static MenuNavigation()
        {
            btnCounter = 0;
        }

        public static void Navigate(KeyboardState keyState, KeyboardState oldKeyState)
        {
            if (keyState.IsKeyDown(Keys.Down) && !oldKeyState.IsKeyDown(Keys.Down))
            {
                btnCounter++;
            }
            else if (keyState.IsKeyDown(Keys.Down) && !oldKeyState.IsKeyDown(Keys.Down))
            {
                btnCounter--;
            }
        }

        public static void Reset()
        {
            btnCounter = 0;
        }
    }
}
