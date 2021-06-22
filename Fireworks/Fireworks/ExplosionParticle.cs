/*
 * Joe Brewer
 * Joe@brewsterware.com
 * http://www.brewsterware.com
 * https://twitter.com/Brewster
 */
using System;
using System.Drawing;

namespace Fireworks
{
    class ExplosionParticle : Particle
    {
        private int alpha;
        private readonly Color color;

        public new Color Color
        {
            get
            {
                return Color.FromArgb(alpha, (random.NextDouble() < 0.05) ? Color.White : color);
            }
        }

        public bool IsBurntOut
        {
            get
            {
                return alpha <= 0;
            }
        }


        public ExplosionParticle(Random randomSeed, ParticleVector initialPosition, int size, Color color) : base(initialPosition, size, color)
        {
            double randomX;
            double randomY;
            random = randomSeed;

            position = new ParticleVector(initialPosition.X, initialPosition.Y);

            randomX = Math.Cos(random.NextDouble() * (Math.PI * 2));
            randomY = Math.Sin(random.NextDouble() * (Math.PI * 2));

            velocity = new ParticleVector(randomX, randomY);
            velocity *= random.Next(1, 6);

            acceleration = new ParticleVector();

            alpha = 255;

            this.color = color;

            this.size = size;
        }

        public override void Update()
        {
            alpha -= 3;

            base.Update();
        }
    }
}
