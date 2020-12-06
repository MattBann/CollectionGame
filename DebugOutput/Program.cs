using System;
using CollectionGameLibrary;

namespace DebugOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playing = true;
            GameboardClass Gameboard = new GameboardClass();

            while (playing)
            {
                Gameboard.AddRandomToBoard();
                Gameboard.DisplayGrid();

                String input = Console.ReadLine();

                switch (input)
                {
                    case "w":
                        Gameboard.MoveUp();
                        break;
                    case "a":
                        Gameboard.MoveLeft();
                        break;
                    case "s":
                        Gameboard.MoveDown();
                        break;
                    case "d":
                        Gameboard.MoveRight();
                        break;
                    case "b":
                        playing = false;
                        break;
                }

                if (Gameboard.CheckGameOver())
                {
                    Console.WriteLine("Game over");
                    playing = false;
                }

            }

            Console.ReadLine();
        }
    }
}
