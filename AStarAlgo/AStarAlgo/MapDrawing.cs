/*
 * Joe Brewer
 * Joe@brewsterware.com
 * http://www.brewsterware.com
 * https://twitter.com/Brewster
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AStarAlgoDemo
{
    public partial class Main
    {
        private void DrawGrid(PaintEventArgs e)
        {
            float gridHeight;
            float gridWidth;

            gridHeight = boxSideLength * columns;
            gridWidth = boxSideLength * columns;

            for (int row = 0; row <= columns; row++)
            {
                e.Graphics.DrawLine(Pens.Black, row * boxSideLength, 0, row * boxSideLength, gridWidth);
            }

            for (int column = 0; column <= columns; column++)
            {
                e.Graphics.DrawLine(Pens.Black, 0, column * boxSideLength, gridHeight, column * boxSideLength);
            }
        }

        private void DrawSpot(Spot spot, Color colour, PaintEventArgs e)
        {
            float x;
            float y;

            if (spot == null)
            {
                return;
            }

            x = spot.Column * boxSideLength;
            y = spot.Row * boxSideLength;

            if (rbSquares.Checked)
            {
                e.Graphics.FillRectangle(new SolidBrush(colour), x + 1, y + 1, boxSideLength - 1, boxSideLength - 1);
            }
            else
            {
                e.Graphics.FillEllipse(new SolidBrush(colour), x + 2, y + 2, boxSideLength - 4, boxSideLength - 4);
            }
        }

        private void DrawLine(Spot fromSpot, Spot toSpot, PaintEventArgs e)
        {
            float x1;
            float y1;
            float x2;
            float y2;

            if (fromSpot == null)
            {
                return;
            }

            x1 = fromSpot.Column * boxSideLength;
            y1 = fromSpot.Row * boxSideLength;

            x2 = toSpot.Column * boxSideLength;
            y2 = toSpot.Row * boxSideLength;

            Pen pen = new Pen(Color.Brown, 4);

            e.Graphics.DrawLine(pen, x1 + boxSideLength / 2, y1 + boxSideLength / 2, x2 + boxSideLength / 2, y2 + boxSideLength / 2);
            // e.Graphics.FillRectangle(new SolidBrush(colour), x + 1, y + 1, boxSideLength - 1, boxSideLength - 1);
        }

        private void DrawCellWall(PaintEventArgs e, Boolean drawWall, float x1, float y1, float x2, float y2)
        {
            Pen penColour;

            penColour = drawWall ? Pens.White : Pens.Aqua;

            e.Graphics.DrawLine(penColour, x1, y1, x2, y2);
        }
    }

}
