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
        static string map = @"Map.txt";
        static string[] display = File.ReadAllLines(map);
        static string[,] mapx = new string[,] { {  }, {  } };
        //Global variables
        
        static void Main(string[] args)
        {
            Console.SetWindowSize(130,30);
            DisplayMap();
            Console.SetCursorPosition(10,10);
            //Game loop
            while (gameOver == false)
            {
                PlayerControl();
            }
        
        
        
        
        
        
        }
        static void DisplayMap()
        {
            for (int y = 0; y < display.Length; y++)
            {
                string row = display[y];
                for (int x = 0; x < row.Length; x++)
                {
                    char tile = row[x];
                    Console.Write(tile);
                    //Thread.Sleep(1);
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
