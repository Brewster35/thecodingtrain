/*
 * Joe Brewer
 * Joe@brewsterware.com
 * http://www.brewsterware.com
 * https://twitter.com/Brewster
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fireworks
{
    public partial class Main : Form
    {
        List<Comet> comets;
        List<CometTail> cometTails;
        List<ExplosionParticle> particles;
        Random random;

        public Main()
        {
            comets = new List<Comet>();
            cometTails = new List<CometTail>();
            particles = new List<ExplosionParticle>();

            InitializeComponent();

            random = new Random();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Color randomColor;

            randomColor = Color.FromArgb((int)(0xFF000000 + (random.Next(0xFFFFFF) & 0x7F7F7F)));

            if (random.NextDouble() < 0.1)
            {
                comets.Add(new Comet(random.Next(PictureBox.Width), PictureBox.Height, 4, randomColor));
            }

            foreach (Comet comet in comets)
            {
                comet.Update();

                cometTails.Add(new CometTail(comet.Position.X, comet.Position.Y, 4, comet.Color));
            }

            foreach (CometTail cometTail in cometTails)
            {
                cometTail.Update();
            }

            // create explosions for all comets that have burnt out
            foreach (Comet comet in comets.FindAll(x => x.IsBurntOut))
            {
                for (int i = 0; i <= 100; i++)
                {
                    particles.Add(new ExplosionParticle(random, comet.Position, 4, comet.Color));
                }
            }

            foreach (ExplosionParticle particle in particles)
            {
                particle.ApplyForce(new ParticleVector());
                particle.Update();
            }

            particles.RemoveAll(x => x.IsBurntOut);
            comets.RemoveAll(x => x.IsBurntOut);
            cometTails.RemoveAll(x => x.IsBurntOut);

            PictureBox.Invalidate();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (Comet comet in comets)
            {
                e.Graphics.FillEllipse(new SolidBrush(comet.Color), comet.Rectangle);
            }

            foreach (CometTail trail in cometTails)
            {
                e.Graphics.FillEllipse(new SolidBrush(trail.Color), trail.Rectangle);
            }

            foreach (ExplosionParticle particle in particles)
            {
                e.Graphics.FillEllipse(new SolidBrush(particle.Color), particle.Rectangle);
            }
        }
    }
}
