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

namespace Matrix
{
    public partial class Main : Form
    {
        List<MatrixStream> matrixStreams;
        Random random;

        const int SymbolSize = 15;

        public void InitialiseStreams()
        {
            MatrixStream matrixStream;
            int x;

            random = new Random();
            matrixStreams = new List<MatrixStream>();

            x = 0;

            for (int i = 0; i <= pictureBox.Width / 15; i++)
            {
                matrixStream = new MatrixStream(random)
                {
                    SymbolSize = Main.SymbolSize
                };

                matrixStream.GenerateSymbols(x, random.Next(-1000, 0));

                matrixStreams.Add(matrixStream);

                x += Main.SymbolSize;
            }
        }

        public Main()
        {
            InitializeComponent();

            InitialiseStreams();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Color color;

            foreach (MatrixStream matrixStream in matrixStreams)
            {
                foreach (Symbol symbol in matrixStream.Symbols)
                {
                    if (symbol.IsFirst)
                    {
                        color = Color.FromArgb(200, 255, 200);
                    }
                    else
                    {
                        color = Color.FromArgb(0, 255, 70);
                    }

                    DrawSymbol(symbol, matrixStream.SymbolSize, color, e);
                }
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            InitialiseStreams();

            pictureBox.Invalidate();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }
    }
}
