using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace snake
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            actions actions = new actions();
            Console.CursorVisible = false;
            snake snake = new snake();
            food food = new food();
            borders output = new borders();
            Thread inputThread = new Thread(new ThreadStart(snake.MoveByInput));
            output.PrintBorders();
            inputThread.Start();
            while (true)
            {
                Thread.Sleep(100);
                if (!food.FoodGenerated)
                {
                    food.GenerateFood(snake);
                }
                snake.EatFruit(food);
                snake.BodyCoordinates.Remove(snake.BodyCoordinates.Last());
                snake.UpdateHeadByDefault();
                output.ClearField();
                output.PrintFruit(food);
                output.PrintSnake(snake);
                Console.SetCursorPosition(2, 25);
                if (actions.SnakeOnBorders(snake) || actions.SnakeEatsItself(snake))
                {
                    Console.SetCursorPosition(21, 12);
                    Console.WriteLine("Game over");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
            }
        }
    }
}