namespace RabitFury.Classes.Menu
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;

    using Enums;
    using Constants;

    public class MenuButton
    {
        private Texture2D[] buttonTextures;
        private string[] buttonStatesDir;
        private float layerDepth;
        private int buttonState;

        public MenuButton(
            Vector2 position,
            float scale,
            ContentManager content,
            float layerDepth,
            string btnNormalStateDir,
            string btnHoverStateDir,
            string btnClickStateDir,
            string btnLockStateDir)
        {
            this.ButtonColor = Color.White;

            this.ButtonPosition = position;
            this.ButtonScale = scale;
            this.LayerDepth = layerDepth;

            this.buttonStatesDir = new string[4];
            this.buttonStatesDir[0] = btnNormalStateDir;
            this.buttonStatesDir[1] = btnHoverStateDir;
            this.buttonStatesDir[2] = btnClickStateDir;
            this.buttonStatesDir[3] = btnLockStateDir;

            this.buttonTextures = new Texture2D[4];
            this.buttonTextures[0] = content.Load<Texture2D>(btnNormalStateDir);
            this.buttonTextures[1] = content.Load<Texture2D>(btnHoverStateDir);
            this.buttonTextures[2] = content.Load<Texture2D>(btnClickStateDir);
            this.buttonTextures[3] = content.Load<Texture2D>(btnLockStateDir);
        }

        public Color ButtonColor { get; private set; }

        public Vector2 ButtonPosition { get; private set; }

        public float ButtonScale { get; private set; }

        public float LayerDepth
        {
            get
            {
                return this.layerDepth;
            }

            set
            {
                if (value < GlobalConstants.MinLayerDepth)
                {
                    this.layerDepth = GlobalConstants.MinLayerDepth;
                }
                else if (value > GlobalConstants.MaxLayerDepth)
                {
                    this.layerDepth = GlobalConstants.MaxLayerDepth;
                }
                else
                {
                    this.layerDepth = value;
                }
            }
        }

        public ButtonStateType ButtonState
        {
            get
            {
                return (ButtonStateType)this.buttonState;
            }

            set
            {
                this.buttonState = (int)value;
            }
        }

        public string[] ButtonStatesDirectory
        {
            get
            {
                return this.buttonStatesDir;
            }
        }

        public Texture2D[] ButtonTextures
        {
            get
            {
                return this.buttonTextures;
            }
        }
    }
}