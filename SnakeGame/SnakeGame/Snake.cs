using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SnakeGame
{
    class Snake
    {
        private List<Point> body;
        private int xDirection;
        private int yDirection;
        private bool isGrowing;
        private bool hasCrashed;

        public int Width;
        public int Height;

        public bool IsAlive;

        public Point Head
        {
            get
            {
                return body[0];
            }
        }

        public bool HasCrashed
        {
            get
            {
                return hasCrashed;
            }
        }

        public Snake()
        {
            body = new List<Point>
            {
                new Point(0, 0)
            };

            xDirection = 0;
            yDirection = 0;

            IsAlive = true;
            isGrowing = false;
        }

        public List<Rectangle> Body
        {
            get
            {
                List<Rectangle> sections = new List<Rectangle>();
                Rectangle section;

                foreach (Point point in body)
                {
                    section = new Rectangle(point.X * Width, point.Y * Height, Width, Height);

                    sections.Add(section);
                }

                return sections;
            }
        }

        public void SetDirection(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                    if (xDirection == 0 &&
                        yDirection == 1)
                    {
                        hasCrashed = true;
                    }

                    xDirection = 0;
                    yDirection = -1;
                    break;

                case Keys.Down:
                    if (xDirection == 0 &&
                        yDirection == -1)
                    {
                        hasCrashed = true;
                    }

                    xDirection = 0;
                    yDirection = 1;
                    break;

                case Keys.Left:
                    if (xDirection == 1 &&
                        yDirection == 0)
                    {
                        hasCrashed = true;
                    }

                    xDirection = -1;
                    yDirection = 0;
                    break;

                case Keys.Right:
                    if (xDirection == -1 &&
                        yDirection == 0)
                    {
                        hasCrashed = true;
                    }

                    xDirection = 1;
                    yDirection = 0;
                    break;
            }
        }

        public bool Eat(Food food)
        {
            return (IsAlive &&
                    body.First() == food.Position);
        }

        public void Grow()
        {
            isGrowing = true;
        }

        public void Update()
        {
            Point head;

            if (!IsAlive)
            {
                return;
            }

            head = body[0];

            if (!isGrowing)
            {
                body.RemoveAt(body.Count - 1);
            }
            else
            {
                isGrowing = false;
            }

            head.X += xDirection;
            head.Y += yDirection;

            body.Insert(0, head);

            if (body.Count(x => x.X == head.X && x.Y == head.Y) > 1)
            {
                hasCrashed = true;
            }
        }
    }
}
