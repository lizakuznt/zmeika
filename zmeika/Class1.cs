using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace snake
{
    internal class food
    {
        public bool FoodGenerated;
        public (int, int) FoodCoordinate;
        public void GenerateFood(snake snake)
        {
            Random random = new Random();
            int x, y;
            x = random.Next(1, 25);
            y = random.Next(1, 25);
            if (!snake.BodyCoordinates.Contains((x, y)))
            {
                FoodGenerated = true;
            }
            FoodCoordinate = (x, y);
        }
    }
}