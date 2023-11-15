using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGPrototype_NathanPeach
{
    internal class Program
    {
        //Global variables
        static int health;//(player health only)
        static bool gameOver;
        //Global variables
        
        static char[,] map = new char[,] 
        {
            { }, 
            { }, 
            { }, 
            { }, 
            { }, 
            { },
        };
        static int width = map.GetLength(1);
        static int height = map.GetLength(0);
        
        static void Main(string[] args)
        {
            
            //Game loop
            while (gameOver == false)
            {
                PlayerControl();
            }

        
        
        
        
        
        
        }
        static void DisplayMap()
        {

        }
        static void PlayerControl()
        {

        }
    }
}
