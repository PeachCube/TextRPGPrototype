using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Threading;

namespace TextRPGPrototype_NathanPeach
{
    internal class Program
    {
        //Global variables
        static int health;//(player health only)
        static bool gameOver;
        static string map = @"Map.txt";
        static string[] display = File.ReadAllLines(map);
        
        //Global variables
        
        static void Main(string[] args)
        {
            Console.SetWindowSize(130,30);
            DisplayMap();
            
            //Game loop
            while (gameOver == false)
            {
                PlayerControl();
            }
            Console.ReadKey();
        
        
        
        
        
        
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
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
                Console.WriteLine();
            }
        }
        static void PlayerControl()
        {

        }
    }
}
