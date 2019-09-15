using System;

namespace MazeGeneration
{
    /// <summary>
    /// this structure holds the state of whether the walls are shown in the Cell object
    /// </summary>
    struct Walls
    {
        public Boolean Top;
        public Boolean Right;
        public Boolean Bottom;
        public Boolean Left;
    }

    /// <summary>
    /// a very simple class to hold information about a single cell in the maze
    /// 
    /// Author: Joe Brewer (Joe@brewsterware.com)
    /// </summary>
    class Cell
    {
        public Boolean Visited;
        public Walls walls;

        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;

            Visited = false;

            walls.Top = true;
            walls.Right = true;
            walls.Bottom = true;
            walls.Left = true;
        }

        public int Row { get; }
        public int Column { get; }
    }
}
