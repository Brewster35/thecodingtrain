using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Main : Form
    {
        Snake snake;
        Food food;
        Stopwatch stopWatch;
        const int Columns = 40;
        const int Rows = 40;

        public Main()
        {
            InitializeComponent();

            stopWatch = new Stopwatch();

            RestartGame();

            ResizeSnakeSections();
        }

        private void RestartGame()
        {
            snake = new Snake();

            ResizeSnakeSections();

            food = new Food(Columns, Rows);
            food.DepositNew();

            stopWatch.Reset();
        }

        private void ResizeSnakeSections()
        {
            if (snake != null)
            {
                snake.Width = PictureBox.Width / Columns;
                snake.Height = PictureBox.Height / Rows;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Point head;

            snake.Update();

            head = snake.Head;

            if (head.X < 0 ||
                head.Y < 0 ||
                head.X > (Columns - 1) ||
                head.Y > (Rows - 1) ||
                snake.HasCrashed)
            {
                EndGame();
            }

            if (snake.Eat(food))
            {
                food.Consume();
                food.DepositNew();

                snake.Grow();
            }

            PictureBox.Invalidate();
        }

        private void EndGame()
        {
            snake.IsAlive = false;
            stopWatch.Stop();
            RestartToolStripMenuItem.Enabled = true;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            //DrawGrid(e);

            DrawSnake(e);
            DrawFood(e);
            DrawScore(e);
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            // Ensure the Form remains square (Height = Width).
            if (control.Size.Height != control.Size.Width)
            {
                control.Size = new Size(control.Size.Width, control.Size.Width);
            }

            ResizeSnakeSections();
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up: 
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    snake.SetDirection(e.KeyCode);

                    RestartToolStripMenuItem.Enabled = false;

                    if (!stopWatch.IsRunning)
                    {
                        stopWatch.Start();
                    }
                    break;
            }
        }

        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
