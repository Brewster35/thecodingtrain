/*
 * Joe Brewer
 * Joe@brewsterware.com
 * http://www.brewsterware.com
 * https://twitter.com/Brewster
 */
using System;
using System.Collections.Generic;

namespace AStarAlgoDemo
{
    class Spot
    {
        private int row;
        private int column;

        public Boolean isObstacle;
        public Spot previous;
        public List<Spot> neighbours;
        public double f;
        public double g;
        public double h;

        public Spot(int row, int column, Random random = null)
        {
            this.row = row;
            this.column = column;

            neighbours = new List<Spot>();

            if (random != null)
            {
                isObstacle = random.NextDouble() < 0.3 ? true : false;
            }
        }

        public void AddNeighbour(Spot spot)
        {
            neighbours.Add(spot);
        }

        public int Row
        {
            get
            {
                return row;
            }
        }

        public int Column
        {
            get
            {
                return column;
            }
        }


    }
}
