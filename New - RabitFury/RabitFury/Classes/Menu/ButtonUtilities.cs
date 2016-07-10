namespace RabitFury.Classes.Menu
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using Verification.Menu;
    using Enums;

    public static class ButtonUtilities
    {
        private static List<MenuButton> buttons;

        static ButtonUtilities()
        {
            buttons = new List<MenuButton>();
        }

        public static MenuButton GenerateButton(
            ContentManager content, 
            Vector2 position, 
            ButtonActionType buttonActionType)
        {
            MenuButton button = null;

            if (buttonActionType == ButtonActionType.Resume)
            {
                button = new MenuButton(
                ButtonActionType.Resume,
                position,
                0.6f,     ////Scale
                content,
                1f,       ////LayerDepth
                "GUI/Btn_Normal",
                "GUI/Btn_Hover",
                "GUI/Btn_Clicked",
                "GUI/Btn_Locked");
            }
            else if (buttonActionType == ButtonActionType.Options)
            {
                button = new MenuButton(
                ButtonActionType.Options,
                position,
                0.6f,     ////Scale
                content,
                1f,       ////LayerDepth
                "GUI/Btn_Normal",
                "GUI/Btn_Hover",
                "GUI/Btn_Clicked",
                "GUI/Btn_Locked");
            }
            else if (buttonActionType == ButtonActionType.Quit)
            {
                button = new MenuButton(
                ButtonActionType.Quit,
                position,
                0.6f,     ////Scale
                content,
                1f,       ////LayerDepth
                "GUI/Btn_Normal",
                "GUI/Btn_Hover",
                "GUI/Btn_Clicked",
                "GUI/Btn_Locked");
            }

            buttons.Add(button);
            return button;
        }



        public static void Load(ContentManager content)
        {
            foreach (var btn in buttons)
            {
                var btnStatesDirs = btn.ButtonStatesDirectory;
                for (int i = 0; i < btnStatesDirs.Length; i++)
                {
                    content.Load<Texture2D>(btnStatesDirs[i]);
                }
            }
        }

        public static void Draw(MenuButton button, SpriteBatch spriteBatch, int buttonStateIndex)
        {
            MenuVerification.ButtonStateTypeVerification(buttonStateIndex);

            spriteBatch.Draw(
                    button.ButtonTextures[buttonStateIndex],
                    button.ButtonPosition,
                    null,
                    Color.White,
                    0f,
                    Vector2.Zero,
                    button.ButtonScale,
                    SpriteEffects.None,
                    button.LayerDepth);
        }
    }
}