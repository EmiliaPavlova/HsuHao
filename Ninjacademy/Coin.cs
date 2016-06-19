using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyTest
{
    public class Coin
    {
        private static float coinCurrFrame;

        public Coin()
        {
            coinCurrFrame = 0;
        }

        public void Animate()
        {
            coinCurrFrame += 0.15f;

            if (coinCurrFrame >= 6.0f)
            {
                coinCurrFrame = 0;
            }
        }

        public int GetCurrCoinFrame
        {
            get
            {
                return (int)coinCurrFrame;
            }
        }
    }
}
