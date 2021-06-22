using System;
using System.Drawing;

namespace SnakeGame
{
    class Food
    {
        private Random random;
        private readonly int columns;
        private readonly int rows;

        private Point position;
        private int consumed;

        public int Consumed
        {
            get
            {
                return consumed;
            }
        }

        public Point Position
        {
            get
            {
                return position;
            }
        }

        public Food(int columns, int rows)
        {
            random = new Random();

            this.columns = columns;
            this.rows = rows;
        }

        public void Consume()
        {
            consumed += 1;
        }

        public void DepositNew()
        {
            position = new Point(random.Next(columns), random.Next(rows));
        }
    }
}
