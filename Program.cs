using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Threading;
using System.Reflection;

namespace TextRPGPrototype_NathanPeach
{
    internal class Program
    {
        //Global variables
        static int health;//(player health only)
        static bool gameOver;
        static string[] display;
        static char[,] map;
        static int width;
        static int height;
        //Global variables

        static void Main(string[] args)
        {
            display = File.ReadAllLines(@"Map.txt");//declares display equal to the strings on Map.txt (fills the display array with the string array on Map.txt)
            height = display.Length;//the length of the display array from line 0 to the last line (the height of the array)
            width = display[0].Length;//the length of a single line in the display array (the width of the line)
            map = new char[width,height];//a 2d array with the same dimensions as display
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[x,y] = display[y][x];//fills the 2d map array with the data in the display array by iterating through the dimensions of the display array with for loops
                }
            }

            Console.SetWindowSize(width+1,height+1);
            DisplayMap();
            Console.SetCursorPosition(10,10);//player starting position
            
            //Game loop
            while (gameOver == false)
            {
                PlayerControl();
            }
        }
        static void DisplayMap()//uses a nested for loop to display each coordinate in the map array and color characters according to if statements
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (map[x,y] == char.Parse("░"))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    else if (map[x, y] == char.Parse("▓"))
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (map[x, y] == char.Parse("X"))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    Console.Write(map[x,y]);
                }
                Console.WriteLine();
            }
        }
        static void PlayerControl()
        {
            ConsoleKey input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.S)
            {
                Console.SetCursorPosition(Console.CursorLeft,Console.CursorTop + 1);
            }
            if (input == ConsoleKey.W)
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            }
            if (input == ConsoleKey.A)
            {
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
            if (input == ConsoleKey.D)
            {
                Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
            }
        }
    }
}
