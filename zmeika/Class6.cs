using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp15;

namespace snake
{
    internal class snake
    {
        ConsoleKeyInfo Key = Console.ReadKey();
        private Movements LastMove = Movements.Right;
        public Borders updown = Borders.UpDown;
        public List<(int, int)> BodyCoordinates = new List<(int, int)>(((int)Borders.UpDown - 2) * ((int)Borders.UpDown - 2))
            {
            (2, (int)Borders.UpDown / 2),
            (1, (int)Borders.UpDown / 2)
            };
        public void UpdateHeadByDefault()
        {
            (int headX, int headY) = BodyCoordinates.First();
            switch (LastMove)
            {
                case Movements.Up:
                    headY--;
                    break;
                case Movements.Down:
                    headY++;
                    break;
                case Movements.Left:
                    headX--;
                    break;
                case Movements.Right:
                    headX++;
                    break;
            }
            BodyCoordinates.Insert(0, (headX, headY));
        }
        public void MoveByInput()
        {
            ConsoleKey GetKey()
            {
                Console.SetCursorPosition(0, (int)Borders.UpDown + 1);
                ConsoleKey inputKey = Console.ReadKey().Key;
                Console.Write(' ');
                return inputKey;
            }
            while (true)
            {
                if (LastMove != Movements.Up || LastMove != Movements.Down || LastMove != Movements.Left || LastMove != Movements.Right)
                {
                    switch (GetKey())
                    {
                        case ConsoleKey.UpArrow:
                            LastMove = Movements.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            LastMove = Movements.Down;
                            break;
                        case ConsoleKey.LeftArrow:
                            LastMove = Movements.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            LastMove = Movements.Right;
                            break;
                    }
                }
            }
        }
        public void EatFruit(food fruit)
        {
            foreach ((int, int) coordinates in BodyCoordinates)
            {
                if (coordinates == fruit.FoodCoordinate)
                {
                    fruit.FoodGenerated = false;
                    BodyCoordinates.Insert(1, coordinates);
                    return;
                }
            }
        }
    }
}