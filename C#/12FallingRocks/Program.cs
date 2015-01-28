using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTest
{
    class Program
    {
        static void Main(string[] args)
        {
            resizeWindow();

            const char DWARF = 'O';
            Rock[] rocks = new Rock[34];
            
            int rocksLenght = rocks.Length;
            bool death = false;

            int dwarfX = 15, dwarfY = 33;

            Console.SetCursorPosition(dwarfX, dwarfY);
            Console.Write(DWARF);

            Random randomGenerator = new Random();

            int n = 0;
            int points = 0;

            while (true)
            {
                if (rocks[n] == null)
                {
                    rocks[n] = new Rock();
                }

                if (rocks[n].getY() == 0)
                {
                    rocks[n].setX(randomGenerator.Next(1, 29));
                    Console.SetCursorPosition(rocks[n].getX(), rocks[n].getY());
                    Console.Write(rocks[n].getImage());
                }

                n = (n == rocksLenght - 1) ? 0 : n + 1;

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        dwarfX--;
                        if (dwarfX <= 1)
                        {
                            dwarfX = 1;
                        }
                    }

                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        dwarfX++;
                        if (dwarfX >= 28)
                        {
                            dwarfX = 28;
                        }
                    }
                }

                for (int i = 0; i < rocksLenght; i++)
                {
                    if (rocks[i] == null) break;

                    if (rocks[i].getY() == 34)
                    {
                        rocks[i].setY(0);
                        rocks[i].setRandomImage();
                    }
                    else
                    {
                        rocks[i].setY(rocks[i].getY() + 1);
                    }
                }

                Console.Clear();

                for (int i = 0; i < rocksLenght; i++)
                {
                    if (rocks[i] == null) break;

                    if (rocks[i].getX() == dwarfX && rocks[i].getY() == dwarfY)
                    {
                        Console.SetCursorPosition(11, 17);
                        Console.Write("DEAD!!!!");
                        Console.SetCursorPosition(4, 19);
                        Console.Write("Press any key to exit!");
                        Console.ReadKey();
                        death = true;
                        break;
                    }
                }

                if (death) break;

                for (int i = 0; i < rocksLenght; i++)
                {
                    if (rocks[i] == null) break;

                    Console.SetCursorPosition(rocks[i].getX(), rocks[i].getY());
                    Console.Write(rocks[i].getImage());
                }

                Console.SetCursorPosition(dwarfX, dwarfY);
                Console.Write(DWARF);

                for (int i = 1; i < 35; i++)
                {
                    Console.SetCursorPosition(30, i);
                    Console.Write('|');
                }

                Console.SetCursorPosition(32, 10);
                Console.Write("Points:");
                points++;
                Console.SetCursorPosition(32, 11);
                Console.Write(points);

                Thread.Sleep(150);
            }
        }

        static void resizeWindow()
        {
            const int PLAYGROUND_HEIGHT = 35;
            const int PLAYGROUND_WIDTH = 40;

            Console.WindowHeight = PLAYGROUND_HEIGHT;
            Console.BufferHeight = Console.WindowHeight;

            Console.WindowWidth = PLAYGROUND_WIDTH;
            Console.BufferWidth = Console.WindowWidth;

            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
