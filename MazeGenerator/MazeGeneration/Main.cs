using System;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGeneration
{
    /// <summary>
    /// the main class that handles the maze generator interface
    /// 
    /// Author: Joe Brewer (Joe@brewsterware.com)
    /// </summary>
    public partial class Main : Form
    {
        private float cellSideLength;
        private int columns = 30;
        private Maze maze;

        public Main()
        {
            InitializeComponent();
            
            SetPictureBoxWidth();

            maze = new Maze(columns, columns);

            SetControlState(false);
        }
        
        /// <summary>
        /// the method resizes and redraws the maze with the correct perspective
        /// and also makes sure that the maze does not overlap with the controls on the 
        /// right of the form
        /// </summary>
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
            if (maze.NextCell())
            {
                pictureBox.Invalidate();
            }
            else
            {
                timer.Enabled = false;

                SetControlState(false);
            }
        }

        private void SetPictureBoxWidth()
        {
            pictureBox.Width = pictureBox.Height;

            cellSideLength = pictureBox.Width / columns;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            // draw all of the cells in the grid in their appropriate places
            for (int i = 0; i < maze.grid.Count; i++)
            {
                DrawCell(maze.grid[i], e);
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

            if (!maze.IsComplete)
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

            SetPictureBoxWidth();

            maze = new Maze(columns, columns);

            // redraw the grid
            pictureBox.Invalidate();
        }

        private void SetControlState(Boolean isRunning)
        {
            txtColumns.Enabled = !isRunning;

            btnStart.Enabled = !isRunning;
            btnReset.Enabled = !isRunning;
            btnPause.Enabled = isRunning;
        }
    }
}
