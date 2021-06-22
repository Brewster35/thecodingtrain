/*
 * Joe Brewer
 * Joe@brewsterware.com
 * http://www.brewsterware.com
 * https://twitter.com/Brewster
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BarnsleyFern
{
    public partial class Main : Form
    {
        BarnsleyFern barnsleyFern;
        public Main()
        {
            InitializeComponent();

            barnsleyFern = new BarnsleyFern();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            timer.Start();
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            barnsleyFern.GeneratePixel();

            pictureBox.Invalidate();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (FernPoint point in barnsleyFern.fernPoints)
            {
                DrawPoint(point, e);
            }
        }

        private void DrawPoint(FernPoint point, PaintEventArgs e)
        {
            double x;
            double y;

            x = point.X.Map(-2.1820, 2.6558, 0, pictureBox.Width);
            y = point.Y.Map(0, 9.9983, pictureBox.Height, 0);

            Point position = new Point((int)Math.Floor(x), (int)Math.Floor(y));

            e.Graphics.FillEllipse(new SolidBrush(point.Colour),
                                    new Rectangle(position, new Size(2, 2)));
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            // Ensure the Form remains square (Height = Width).
            if (control.Size.Height != control.Size.Width)
            {
                control.Size = new Size(control.Size.Width, control.Size.Width);
            }

            pictureBox.Invalidate();
        }
    }
}
