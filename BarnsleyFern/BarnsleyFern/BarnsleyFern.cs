/*
 * Joe Brewer
 * Joe@brewsterware.com
 * http://www.brewsterware.com
 * https://twitter.com/Brewster
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BarnsleyFern
{
    class FernPoint
    {
        public FernPoint(double x, double y, Color colour)
        {
            X = x;
            Y = y;
            Colour = colour; 
        }

        public double X;
        public double Y;
        public Color Colour;
    }

    class BarnsleyFern
    {
        private List<Color> colours;
        private Random random;
        public List<FernPoint> fernPoints;
        private double x;
        private double y;

        public BarnsleyFern()
        {
            random = new Random();
            fernPoints = new List<FernPoint>();
            colours = new List<Color>();

            PopulateColors();
        }

        private void PopulateColors()
        {
            colours.Add(Color.Blue);
            colours.Add(Color.Red);
            colours.Add(Color.Coral);
            colours.Add(Color.Cyan);
            colours.Add(Color.ForestGreen);
        }

        private Color GetRandomColour()
        {
            colours.Shuffle();

            return colours[0];
        }

        public void GeneratePixel()
        {
            double nextX;
            double nextY;
            Color colour;

            double probability = random.NextDouble();

            if (probability < 0.01)
            {
                nextX = 0;
                nextY = 0.16 * y;
            }
            else if (probability < 0.86)
            {
                nextX = 0.85 * x + 0.04 * y;
                nextY = -0.04 * x + 0.85 * y + 1.6;
            }
            else if (probability < 0.93)
            {
                nextX = 0.2 * x + -0.26 * y;
                nextY = 0.23 * x + 0.22 * y + 1.6;
            }
            else
            {
                nextX = -0.15 * x + 0.28 * y;
                nextY = 0.26 * x + 0.24 * y + 0.44;
            }

            colour = GetRandomColour();
            x = nextX;
            y = nextY;

            fernPoints.Add(new FernPoint(x, y, colour));
        }
    }
}
