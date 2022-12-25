using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleApp15;

namespace snake
{
    internal class borders
    {
        char Snake = '+';
        char Head = '=';
        char Food = '*';
        private (int, int) ConvertToOutputCoordinate((int, int) coordinate)
        {
            (int x, int y) = coordinate;
            return (x * 2, y);
        }
        public void PrintBorders()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i <= 50; i++)
            {
                Console.Write("#");
            }
            Console.SetCursorPosition(0, (int)Borders.UpDown);
            for (int i = 0; i <= 50; i++)
            {
                Console.Write("#");
            }
            for (int i = 0; i <= 25; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('#');
            }
            for (int i = 0; i <= 25; i++)
            {
                Console.SetCursorPosition((int)Borders.LeftRight, i);
                Console.Write('#');
            }
        }
        public void PrintSnake(snake snake)
        {
            foreach ((int, int) coordinate in snake.BodyCoordinates)
            {
                (int consoleX, int consoleY) = ConvertToOutputCoordinate(coordinate);
                Console.SetCursorPosition(consoleX, consoleY);
                Console.Write(coordinate == snake.BodyCoordinates.First() ? Head : Snake);
            }
        }
        public void PrintFruit(food fruit)
        {
            (int consoleX, int consoleY) = ConvertToOutputCoordinate(fruit.FoodCoordinate);
            Console.SetCursorPosition(consoleX, consoleY);
            Console.Write(Food);
        }
        public void ClearField()
        {
            for (int i = 1; i < (int)Borders.UpDown; i++)
            {
                Console.SetCursorPosition(1, i);
                for (int j = 0; j < (int)Borders.LeftRight - 1; j++)
                {
                    Console.Write(' ');
                }
            }
        }
    }
}