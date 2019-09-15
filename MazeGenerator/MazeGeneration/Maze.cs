using System;
using System.Collections.Generic;

namespace MazeGeneration
{
    /// <summary>
    /// the class creates a maze using the recursive backtracker algorithm
    /// as described here: https://en.wikipedia.org/wiki/Maze_generation_algorithm
    /// 
    /// This is based on the work of Daniel Shiffman (https://www.youtube.com/channel/UCvjgXvBlbQiydffZU7m1_aw)
    /// 
    /// Author: Joe Brewer (Joe@brewsterware.com)
    /// </summary>
    class Maze
    {
        private Boolean isComplete;
        public List<Cell> grid;
        public Cell current;
        private int totalColumns;
        private Random random;
        private Stack<Cell> stack;

        public Maze(int rows, int cols)
        {
            Cell cell;

            isComplete = false;
            totalColumns = cols;

            random = new Random();
            stack = new Stack<Cell>();
            grid = new List<Cell>();

            // create the grid
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    cell = new Cell(row, col);

                    grid.Add(cell);
                }
            }

            // set the start to the top left of the grid
            current = grid[0];
            current.Visited = true;
        }

        public Boolean IsComplete
        {
            get
            {
                return isComplete;
            }
        }

        public Boolean IsCellInStack(Cell cell)
        {
            return stack.Contains(cell);
        }

        /// <summary>
        /// this method creates the next cell in the maze sequence and contains the main
        /// part of the recursive backtracker algorithm
        /// </summary>
        /// <returns>true if there are more cells to generate for the maze, false if it is complete</returns>
        public Boolean NextCell()
        {
            Cell next;

            next = GetRandomNeighbour();

            if (next != null)
            {
                next.Visited = true;
                
                stack.Push(current);

                RemoveWalls(current, next);

                current = next;

                return true;
            }
            else if (stack.Count > 0)
            {
                current = stack.Pop();

                return true;
            }

            isComplete = true;

            return false;
        }

        /// <summary>
        /// this method returns the wall that connects two cells
        /// </summary>
        /// <param name="current">the current cell</param>
        /// <param name="next">the next cell in the sequence</param>
        private void RemoveWalls(Cell current, Cell next)
        {
            int x;
            int y;

            y = current.Row - next.Row;
            x = current.Column - next.Column;

            if (x == 1)
            {
                current.walls.Left = false;
                next.walls.Right = false;
            }
            else if (x == -1)
            {
                current.walls.Right = false;
                next.walls.Left = false;
            }

            if (y == 1)
            {
                current.walls.Top = false;
                next.walls.Bottom = false;
            }
            else if (y == -1)
            {
                current.walls.Bottom = false;
                next.walls.Top = false;
            }
        }

        /// <summary>
        /// the method converts a grid reference of row and column into a single 
        /// array index
        /// </summary>
        /// <param name="row">row number</param>
        /// <param name="column">column number</param>
        /// <returns>array index</returns>
        private int Index(int row, int column)
        {
            // make sure the we dont return an element beyond the bounds of the grid
            if (row < 0 || column < 0 || 
                row > totalColumns - 1 || column > totalColumns - 1)
            {
                return -1;
            }

            return row + column * totalColumns;
        }

        /// <summary>
        /// this method returns a random neighbour of the current Cell that has not been visited
        /// </summary>
        /// <returns>a Cell object</returns>
        private Cell GetRandomNeighbour()
        {
            List<Cell> neighbours = new List<Cell>();

            void AddNeighbour(int index)
            {
                if (index != -1 &&
                    !grid[index].Visited)
                {
                    neighbours.Add(grid[index]);
                }
            }

            // top
            AddNeighbour(Index(current.Row, current.Column - 1));

            // right
            AddNeighbour(Index(current.Row + 1, current.Column));

            // bottom
            AddNeighbour(Index(current.Row, current.Column + 1));

            // left
            AddNeighbour(Index(current.Row  - 1, current.Column));

            if (neighbours.Count > 0)
            {
                // randomly shuffle the neighbours list
                neighbours.Shuffle();

                // return the first element from the shuffled list
                // this seems to work better than using the Random class to 
                // generate a random element in the neighbours list
                return neighbours[0];
            }

            // no valid neighbours found, return null
            return (Cell)null;
        }
    }
}
