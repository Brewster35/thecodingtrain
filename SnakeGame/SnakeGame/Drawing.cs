using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Main
    {
        private void DrawGrid(PaintEventArgs e)
        {
            int colWidth = PictureBox.Width / Columns;
            int rowHeight = PictureBox.Height / Rows;
            Pen pen;

            pen = new Pen(new SolidBrush(Color.Black));

            for (int column = 1; column <= Columns; column++)
            {
                e.Graphics.DrawLine(pen, 
                    new Point(column * colWidth, 0), 
                    new Point(column * colWidth, PictureBox.Height));
            }

            for (int row = 1; row <= Rows; row++)
            {
                e.Graphics.DrawLine(pen, 
                    new Point(0, row * rowHeight), 
                    new Point(PictureBox.Width, row * rowHeight));
            }
        }

        private void DrawSnake(PaintEventArgs e)
        {
            List<Rectangle> snakeBody;

            snakeBody = snake.Body;

            foreach(Rectangle section in snakeBody)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), section);
            }
        }

        private void DrawFood(PaintEventArgs e)
        {
            int colWidth = PictureBox.Width / Columns;
            int rowHeight = PictureBox.Height / Rows;

            e.Graphics.FillRectangle(new SolidBrush(Color.Green), 
                food.Position.X * colWidth, 
                food.Position.Y * rowHeight, 
                colWidth, 
                rowHeight);
        }

        private void DrawScore(PaintEventArgs e)
        {
            Font font;
            Brush brush;
            TimeSpan timeSpan;

            timeSpan = stopWatch.Elapsed;

            font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold, GraphicsUnit.Pixel);
            brush = new SolidBrush(Color.Black);

            e.Graphics.DrawString(string.Format("Score: {0}", food.Consumed), font, brush, 10, 10);
            e.Graphics.DrawString(string.Format("Time: {0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds), font, brush, 10, 30);
        }
    }
}
