using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace snake
{
    internal class actions
    {
        public actions()
        {
            Console.WindowHeight = 27;
            Console.WindowWidth = 52;
        }
        public bool SnakeOnBorders(snake snake)
        {
            (int x, int y) = snake.BodyCoordinates.First();
            return x == 0 || y == 0 || x >= 25 || y >= 25;
        }
        public bool SnakeEatsItself(snake snake)
        {
            for (int i = 4; i < snake.BodyCoordinates.Count; i++)
            {
                if (snake.BodyCoordinates.First() == snake.BodyCoordinates[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}