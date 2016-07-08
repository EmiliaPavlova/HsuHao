namespace RabitFury.Classes.Menu
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Enums;
    using Constants;

    public class MenuButton
    {
        private Texture2D[] buttonTextures;
        float layerDepth;
        int buttonState;

        public MenuButton(
            Vector2 position,
            Vector2 size,
            float layerDepth,
            Texture2D textureNormalState,
            Texture2D textureHoverState,
            Texture2D textureClickState,
            Texture2D textureLockState)
        {
            this.ButtonColor = Color.White;

            this.ButtonPosition = position;
            this.ButtonSize = size;

            this.buttonTextures = new Texture2D[4];
            this.buttonTextures[0] = textureNormalState;
            this.buttonTextures[1] = textureHoverState;
            this.buttonTextures[2] = textureClickState;
            this.buttonTextures[3] = textureLockState;
        }

        public Color ButtonColor { get; private set; }

        public Vector2 ButtonPosition { get; private set; }

        public Vector2 ButtonSize { get; private set; }

        public float LayerDepth
        {
            get
            {
                return this.layerDepth;
            }

            set
            {
                if (value < Global.MIN_LAYER_DEPTH)
                {
                    this.layerDepth = Global.MIN_LAYER_DEPTH;
                }
                else if (value > Global.MAX_LAYER_DEPTH)
                {
                    this.layerDepth = Global.MAX_LAYER_DEPTH;
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

        public Texture2D[] ButtonTextures
        {
            get
            {
                return this.buttonTextures;
            }
        }
    }
}