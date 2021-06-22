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
    public partial class Main : Form
    {
        private float boxSideLength;
        private int columns = 30;
        private int rows = 30;
        Map map;
        MapPathfinder mapPathFinder;

        public Main()
        {
            InitializeComponent();
            
            SetPictureBoxWidth();

            map = new Map(rows, columns);
            mapPathFinder = new MapPathfinder(map);

            SetControlState(false);
        }
        
        private void Main_Resize(object sender, EventArgs e)
        {
            Size minSize = new Size
            {
                Width = this.Height + 100
            };

            this.MinimumSize = minSize;

            SetPictureBoxWidth();

            pictureBox.Invalidate();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (mapPathFinder.NextSpot())
            {
                pictureBox.Invalidate();
            }
            else
            {
                // invalidate one last time to draw the path
                pictureBox.Invalidate();

                timer.Enabled = false;

                SetControlState(false);
            }
        }

        private void SetPictureBoxWidth()
        {
            pictureBox.Width = pictureBox.Height;

            boxSideLength = pictureBox.Width / columns;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (rbSquares.Checked)
            {
                DrawGrid(e);

                // draw spots from the open set
                if (mapPathFinder.OpenCount > 0)
                {
                    for (int i = 0; i < mapPathFinder.OpenCount; i++)
                    {
                        DrawSpot(mapPathFinder.Open(i), Color.Green, e);
                    }
                }

                // draw spots from the closed set
                if (mapPathFinder.ClosedCount > 0)
                {
                    for (int i = 0; i < mapPathFinder.ClosedCount; i++)
                    {
                        DrawSpot(mapPathFinder.Closed(i), Color.Red, e);
                    }
                }
            }

            if (rbSquares.Checked)
            {
                // draw the path
                for (int i = 0; i < mapPathFinder.path.Count; i++)
                {
                    DrawSpot(mapPathFinder.path[i], Color.Blue, e);
                }
            }
            else
            {
                // draw the path
                for (int i = 0; i < mapPathFinder.path.Count - 1; i++)
                {
                    DrawLine(mapPathFinder.path[i], mapPathFinder.path[i + 1], e);
                }
            }

            // draw the obstacles
            var obstacles = map.grid.FindAll(x => x.isObstacle == true);

            foreach (Spot obstacle in obstacles)
            {
                DrawSpot(obstacle, Color.Black, e);
            }

            if (map.HasHighlightedCell)
            {
                Spot highlight = new Spot(map.highlightRow, map.highlightColumn);
                DrawSpot(highlight, Color.Yellow, e);
            }
        }

        private void TxtColumns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && 
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            timer.Start();

            if (!mapPathFinder.IsComplete)
            {
                SetControlState(true);
            }
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            timer.Stop();

            SetControlState(false);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            columns = int.Parse(txtColumns.Text);
            rows = columns;

            SetPictureBoxWidth();

            map = new Map(rows, columns);
            mapPathFinder = new MapPathfinder(map);

            // redraw the grid
            pictureBox.Invalidate();
        }

        private void SetControlState(Boolean isRunning)
        {
            txtColumns.Enabled = !isRunning;

            btnStart.Enabled = !isRunning;
            btnReset.Enabled = !isRunning;
            btnPause.Enabled = isRunning;

            rbSquares.Enabled = !isRunning;
            rbCircles.Enabled = !isRunning;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            int row;
            int column;

            row = (int)Math.Floor(e.Y / boxSideLength);
            row = (row < rows) ? row : -1;

            column = (int)Math.Floor(e.X / boxSideLength);
            column = (column < columns) ? column : -1;

            MoveMouse(row, column);
        }

        private void MoveMouse(int row, int column)
        {
            if (mapPathFinder.IsComplete ||
                (row == -1 ||
                column == -1) ||
                (row == map.highlightRow &&
                column == map.highlightColumn))
            {
                return;
            }

            map.highlightRow = row;
            map.highlightColumn = column;

            pictureBox.Invalidate();
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mapPathFinder.IsComplete || 
                map.HasHighlightedCell)
            {
                map.highlightRow = -1;
                map.highlightColumn = -1;

                pictureBox.Invalidate();
            }
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            int row;
            int column;
            Spot spot;

            row = (int)Math.Floor(e.Y / boxSideLength);
            row = (row < rows) ? row : -1;

            column = (int)Math.Floor(e.X / boxSideLength);
            column = (column < columns) ? column : -1;

            if (row == -1 ||
                column == -1)
            {
                return;
            }

            spot = map.Spot(row, column);
            spot.isObstacle = !spot.isObstacle;
        }

        private void RbSquares_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }

        private void RbCircles_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }
    }
}
