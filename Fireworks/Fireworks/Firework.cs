/*
 * Joe Brewer
 * Joe@brewsterware.com
 * http://www.brewsterware.com
 * https://twitter.com/Brewster
 */
using System.Drawing;

namespace Fireworks
{
    class Firework
    {
        protected Particle firework;
        protected ParticleVector lastPosition;
        protected bool isBurntOut;

        public RectangleF Rectangle
        {
            get
            {
                return firework.Rectangle;
            }
        }

        public ParticleVector Position
        {
            get
            {
                return firework.Position;
            }
        }

        public Color Color
        {
            get
            {
                return firework.Color;
            }
        }

        public bool IsBurntOut
        {
            get
            {
                return isBurntOut;
            }
        }

        public Firework(double x, double y, int size, Color color)
        {
            firework = new Particle(x, y, size, color);
            lastPosition = new ParticleVector(x, y);

            isBurntOut = false; ;
        }

        public virtual void Update()
        {
        }
    }
}
