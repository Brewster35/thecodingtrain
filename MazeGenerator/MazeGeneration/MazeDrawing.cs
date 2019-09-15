using System;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGeneration
{
    /// <summary>
    /// these functions deal with the drawing of the maze on the PictureBox object
    /// 
    /// Author: Joe Brewer (Joe@brewsterware.com)
    /// </summary>
    public partial class Main
    {
        private void DrawCell(Cell cell, PaintEventArgs e)
        {
            float x;
            float y;

            x = cell.Column * cellSideLength;
            y = cell.Row * cellSideLength;

            DrawCellWall(e, cell.walls.Top, x, y, x + cellSideLength, y);
            DrawCellWall(e, cell.walls.Right, x + cellSideLength, y, x + cellSideLength, y + cellSideLength);
            DrawCellWall(e, cell.walls.Bottom, x + cellSideLength, y + cellSideLength, x, y + cellSideLength);
            DrawCellWall(e, cell.walls.Left, x, y + cellSideLength, x, y);

            // paint the cells that have already been visited
            if (cell.Visited)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Aqua), x + 1, y + 1, cellSideLength - 1, cellSideLength - 1);
            }

            // highlight the current cell
            if (cell == maze.current)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Purple), x + 1, y + 1, cellSideLength - 1, cellSideLength - 1);
            }

            // draw a dot in the cells that are in the stack
            if (chkShowCellsInStack.Checked &&
                maze.IsCellInStack(cell))
            {
                Point position = new Point((int)Math.Floor(x + (cellSideLength / 2)) - 2, (int)Math.Floor(y + (cellSideLength / 2)) - 2);

                e.Graphics.FillEllipse(new SolidBrush(Color.Red),
                                        new Rectangle(position, new Size(4, 4)));
            }
        }

        private void DrawCellWall(PaintEventArgs e, Boolean drawWall, float x1, float y1, float x2, float y2)
        {
            Pen penColour;

            penColour = drawWall ? Pens.White : Pens.Aqua;

            e.Graphics.DrawLine(penColour, x1, y1, x2, y2);
        }
    }

}
