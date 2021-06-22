/*
 * Joe Brewer
 * Joe@brewsterware.com
 * http://www.brewsterware.com
 * https://twitter.com/Brewster
 */
using System.Drawing;
using System.Windows.Forms;

namespace Matrix
{
    public partial class Main
    {
        private void DrawSymbol(Symbol symbol, int symbolSize, Color colour, PaintEventArgs e)
        {
            Font font;

            if (random.Next(0, 8) == 0)
            {
                symbol.SetToRandomSymbol();
            }

            symbol.Y = (symbol.Y > pictureBox.Height) ? 0 : symbol.Y + symbol.Speed;

            font = new Font("Microsoft YaHei UI Light", symbolSize, symbol.IsFirst ? FontStyle.Bold : FontStyle.Regular);

            e.Graphics.DrawString(symbol.Char, font, new SolidBrush(colour), symbol.X, symbol.Y);
        }
    }
}
