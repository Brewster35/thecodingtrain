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
    class Map
    {
        private int totalColumns;
        private int totalRows;

        public List<Spot> grid;

        public int highlightRow;
        public int highlightColumn;

        public Map(int rows, int cols)
        {
            Random random;
            Spot spot;

            totalColumns = cols;
            totalRows = rows;

            highlightRow = -1;
            highlightColumn = -1;

            random = new Random();

            grid = new List<Spot>();
           
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    spot = new Spot(row, col, random);

                    grid.Add(spot);
                }
            }

            AddNeighbours();
        }

        public int TotalColumns
        {
            get
            {
                return totalColumns;
            }
        }

        public int TotalRows
        {
            get
            {
                return totalRows;
            }
        }

        public Boolean HasHighlightedCell
        {
            get
            {
                return highlightRow != -1 && highlightColumn != -1;
            }
        }
        
        private void AddNeighbours()
        {
            Spot spot;

            void AddNeighbour(int row, int column)
            {
                Spot neighbour;

                if (Index(row, column) != -1)
                {
                    neighbour = grid[Index(row, column)];

                    spot.AddNeighbour(neighbour);
                }
            }

            for (int i = 0; i < grid.Count - 1; i++)
            {
                spot = grid[i];

                // horizontal and vertical neighbours
                AddNeighbour(spot.Row + 1, spot.Column);
                AddNeighbour(spot.Row - 1, spot.Column);
                AddNeighbour(spot.Row, spot.Column + 1);
                AddNeighbour(spot.Row, spot.Column - 1);

                // diagonal neighbours
                AddNeighbour(spot.Row - 1, spot.Column - 1);
                AddNeighbour(spot.Row + 1, spot.Column - 1);
                AddNeighbour(spot.Row - 1, spot.Column + 1);
                AddNeighbour(spot.Row + 1, spot.Column + 1);
            }
        }

        public Spot Spot(int row, int column)
        {
            return grid[Index(row, column)];
        }

        private int Index(int row, int column)
        {
            if (row < 0 || column < 0 || 
                row > totalColumns - 1 || column > totalColumns - 1)
            {
                return -1;
            }

            return row + column * totalColumns;
        }

    }
}
