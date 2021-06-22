/*
 * Joe Brewer
 * Joe@brewsterware.com
 * http://www.brewsterware.com
 * https://twitter.com/Brewster
 */
using System.Drawing;

namespace Fireworks
{
    class CometTail : Firework
    {
        private int alpha;

        public new Color Color
        {
            get
            {
                return Color.FromArgb(alpha, firework.Color);
            }
        }

        public CometTail(double x, double y, int size, Color color) : base(x, y, size, color)
        {
            alpha = 255;
        }

        public override void Update()
        {
            alpha -= 15;

            if (alpha <= 0)
            {
                isBurntOut = true;
            }
        }
    }
}
