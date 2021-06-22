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
    class Particle
    {
        protected ParticleVector position;
        protected ParticleVector velocity;
        protected ParticleVector acceleration;
        protected int size;
        protected Random random;

        public Color Color;

        public ParticleVector Velocity
        {
            get
            {
                return velocity;
            }
        }

        public ParticleVector Position
        {
            get
            {
                return position;
            }
        }

        public RectangleF Rectangle
        {
            get
            {
                return new RectangleF((int)(position.X - (size / 2)), (int)(position.Y - (size / 2)), size, size);
            }
        }

        public Particle(double x, double y, int size, Color color)
        {
            random = new Random();

            position = new ParticleVector(x, y);
            velocity = new ParticleVector(0, random.Next(-12, -8));
            acceleration = new ParticleVector(0, 0);

            Color = color;

            this.size = size;
        }

        public Particle(ParticleVector initialPosition, int size, Color color)
        {
            random = new Random();

            position = new ParticleVector(initialPosition.X, initialPosition.Y);
            velocity = new ParticleVector(y:random.Next(-12, -8));
            acceleration = new ParticleVector();

            this.size = size;
        }

        public void ApplyForce(ParticleVector force)
        {
            acceleration += force;
        }

        public virtual void Update()
        {
            velocity += acceleration;
            position += velocity;

            acceleration *= 0;
        }
    }

    class ParticleVector
    {
        public double X;
        public double Y;

        public ParticleVector(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }

        public static ParticleVector operator +(ParticleVector a, ParticleVector b)
        {
            return new ParticleVector(a.X + b.X, a.Y + b.Y);
        }

        public static ParticleVector operator +(ParticleVector a, double b)
        {
            return new ParticleVector(a.X + b, a.Y + b);
        }

        public static ParticleVector operator *(ParticleVector a, double b)
        {
            return new ParticleVector(a.X * b, a.Y * b);
        }
    }
}
