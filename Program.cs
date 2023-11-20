using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextRPGPrototype_NathanPeach
{
    internal class Program
    {
        //Global variables
        static int health;//(player health only)
        static bool gameOver;
        //Global variables
        
        static void Main(string[] args)
        {
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
            string map = @"Map.txt";
            string display = File.ReadAllText(map);
            Console.Write(display);
        }
        static void PlayerControl()
        {

        }
    }
}
