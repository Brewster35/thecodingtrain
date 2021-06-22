/*
 * Joe Brewer
 * Joe@brewsterware.com
 * http://www.brewsterware.com
 * https://twitter.com/Brewster
 */
using System.Drawing;

namespace Fireworks
{
    class Comet : Firework
    {
        public Comet(double x, double y, int size, Color color) : base(x, y, size, color)
        {
        }

        public override void Update()
        {
            ParticleVector gravity;

            gravity = new ParticleVector(y:0.15);

            firework.ApplyForce(gravity);
            firework.Update();

            if (firework.Velocity.Y >= 0)
            {
                isBurntOut = true;
            }
        }
    }
}
