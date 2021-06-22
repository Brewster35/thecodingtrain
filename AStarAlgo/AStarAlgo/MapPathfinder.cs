/*
 * Joe Brewer
 * Joe@brewsterware.com
 * http://www.brewsterware.com
 * https://twitter.com/Brewster
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace AStarAlgoDemo
{
    class MapPathfinder
    {
        private Boolean isComplete;

        private int totalColumnsInMap;

        private List<Spot> grid;
        private List<Spot> openSet;
        private List<Spot> closedSet;
        public List<Spot> path;

        private Spot start;
        private Spot end;

        public MapPathfinder(Map map)
        {
            closedSet = new List<Spot>();
            path = new List<Spot>();

            this.grid = map.grid;
            this.totalColumnsInMap = map.TotalColumns;

            SetStart(0, 0);
            SetEnd(map.TotalRows - 1, map.TotalColumns - 1);
        }

        public void SetStart(int row, int column)
        {
            openSet = new List<Spot>();

            start = grid[row + column * totalColumnsInMap];

            openSet.Add(start);
        }

        public void SetEnd(int row, int column)
        {
            end = grid[row + column * totalColumnsInMap];
        }

        public Boolean IsComplete
        {
            get
            {
                return isComplete;
            }
        }

        public int OpenCount
        {
            get
            {
                return openSet.Count;
            }
        }

        public Spot Open(int index)
        {
            return openSet[index];
        }

        public int ClosedCount
        {
            get
            {
                return closedSet.Count;
            }
        }

        public Spot Closed(int index)
        {
            return closedSet[index];
        }

        public Boolean NextSpot()
        {
            Spot current;
            Spot temp;
            Boolean newPath;
            int winner = 0;
            double tempG = 0;

            if (openSet.Count > 0)
            {
                path = new List<Spot>();

                for (int i = 0; i < openSet.Count; i++)
                {
                    if (openSet[i].f < openSet[winner].f)
                    {
                        winner = i;
                    }
                }

                current = openSet[winner];

                temp = current;
                path.Add(temp);
                while (temp.previous != null)
                {
                    path.Add(temp.previous);
                    temp = temp.previous;
                }

                if (current == end)
                {
                    // we are done!
                    isComplete = true;
                    return false;
                }

                openSet.RemoveAt(winner);
                closedSet.Add(current);

                foreach (Spot neighbour in current.neighbours)
                {
                    newPath = false;

                    if (!closedSet.Contains(neighbour) &&
                        !neighbour.isObstacle)
                    {
                        tempG = current.g + 1;

                        if (openSet.Contains(neighbour))
                        {
                            if (tempG < neighbour.g)
                            {
                                newPath = true;
                                neighbour.g = tempG;
                            }
                        }
                        else
                        {
                            newPath = true;
                            neighbour.g = tempG;
                            openSet.Add(neighbour);
                        }

                        if (newPath)
                        {
                            neighbour.h = Heuristic(neighbour, end);
                            neighbour.f = neighbour.g + neighbour.h;
                            neighbour.previous = current;
                        }
                    }
                }

                return true;
            }

            isComplete = true;

            return false;
        }

        private double Heuristic(Spot neighbour, Spot end)
        {
            double distance;

            // Euclidean distance
            distance = new Point(neighbour.Row, neighbour.Column).Distance(new Point(end.Row, end.Column));

            // taxi cab distance
            // distance = Math.Abs(neighbour.Row - end.Row) + Math.Abs(neighbour.Column - end.Column);

            return distance;
        }
    }
}
