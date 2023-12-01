using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Threading;
using System.Reflection;
using System.Net.Mime;

namespace TextRPGPrototype_NathanPeach
{
    internal class Program
    {
        //Global variables
        static int health;//(player health only)
        static int eHealth;//(enemy health)
        static bool gameOver;
        static string[] display;
        static char[,] map;
        static int width;
        static int height;
        static char wall;
        static char water;
        static Random randAI;
        static bool enemyAlive;
        public struct PlayerXY
        {
            static public int x;
            static public int y;
        }
        public struct EnemyXY
        {
            static public int x;
            static public int y;
        }
        //Global variables

        static void Main(string[] args)
        {
            display = File.ReadAllLines(@"Map.txt");//declares display equal to the strings on Map.txt (fills the display array with the string array on Map.txt)
            height = display.Length;//the length of the display array from line 0 to the last line (the height of the array)
            width = display[0].Length;//the length of a single line in the display array (the width of the line)
            map = new char[width,height];//a 2d array with the same dimensions as display
            wall = char.Parse("▓");//sets the "wall" variable char equal to "▓"
            water = char.Parse("~");//sets the "water" variable char equal to "~"
            randAI = new Random();
            health = 10;
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[x,y] = display[y][x];//fills the 2d map array with the data in the display array by iterating through the dimensions of the display array with for loops
                }
            }

            DisplayMap();
            Console.SetWindowSize(width + 1, height + 2);
            Console.SetBufferSize(width + 1, height + 2);
            PlayerXY.x = 10;//player starting position
            PlayerXY.y = 10;
            Console.SetCursorPosition(PlayerXY.x,PlayerXY.y);
            EnemyXY.x = 25;//enemy starting position
            EnemyXY.y = 8;
            gameOver = false;
            enemyAlive = true;
            
            //Game loop
            while (gameOver == false)
            {
                DisplayStats();
                PlayerControl();
                PlayerDeath();
                EnemyDeath();
                EnemyAI();
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
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (map[x,y] == wall)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (map[x,y] == char.Parse("X"))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (map[x,y] == water)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.Write(map[x,y]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }
        static void DisplayStats()
        {
            Console.SetCursorPosition(0,height+1);
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("HP: ");
            Console.Write(health);
            Console.ForegroundColor = ConsoleColor.White; 
            //for (int i = 0; i < health; i++)
            //{
                //Console.BackgroundColor = ConsoleColor.Red;
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.Write("▓");
            //}
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void PlayerControl()
        {
            Console.SetCursorPosition(PlayerXY.x, PlayerXY.y);
            Console.Write("0");
            ConsoleKey input = Console.ReadKey(true).Key;
            if ((input == ConsoleKey.S) && (map[PlayerXY.x, PlayerXY.y + 1] != wall))//if an "S" input is detected on the keyboard, and the char 1 unit above the player  
            {                                                                        //position in the map array is not a wall or an enemy, change the player position y value by + 1.
                if ((PlayerXY.y + 1 == EnemyXY.y))// && (PlayerXY.x != EnemyXY.x))
                {
                    eHealth -= 1;
                }
                else 
                {
                    PlayerXY.y += 1;
                }
            }
            if ((input == ConsoleKey.W) && (map[PlayerXY.x, PlayerXY.y - 1] != wall))
            {
                if ((PlayerXY.y - 1 == EnemyXY.y))// && (PlayerXY.x != EnemyXY.x))
                {
                    eHealth -= 1;
                }
                else
                {
                    PlayerXY.y -= 1;
                }
            }
            if ((input == ConsoleKey.A) && (map[PlayerXY.x - 1, PlayerXY.y] != wall))
            {
                if ((PlayerXY.x - 1 == EnemyXY.x))// && (PlayerXY.x -1 != EnemyXY.x))
                {
                    eHealth -= 1;
                }
                else
                {
                    PlayerXY.x -= 1;
                }
            }
            if ((input == ConsoleKey.D) && (map[PlayerXY.x + 1, PlayerXY.y] != wall))
            {
                if ((PlayerXY.x + 1 == EnemyXY.x))// && (PlayerXY.x + 1 != EnemyXY.x))
                {
                    eHealth -= 1;
                }
                else
                {
                    PlayerXY.x += 1;
                }
            }
        }
        static void EnemyAI()
        {
            int moveRoll = randAI.Next(0,4);
            Console.SetCursorPosition(EnemyXY.x, EnemyXY.y);
            Console.Write(8);
            if ((map[EnemyXY.x, EnemyXY.y + 1] != wall) && (moveRoll == 0))
            {
                if ((EnemyXY.y + 1 == PlayerXY.y)) //&& (EnemyXY.x != PlayerXY.x))
                {
                    health -= 1;
                }
                else
                {
                    EnemyXY.y += 1;
                }
            }
            if ((map[EnemyXY.x, EnemyXY.y - 1] != wall) && (moveRoll == 1))
            {
                if ((EnemyXY.y - 1 == PlayerXY.y)) //&& (EnemyXY.x != PlayerXY.x))
                {
                    health -= 1;
                }
                else
                {
                    EnemyXY.y -= 1;
                }
            }
            if ((map[EnemyXY.x - 1, EnemyXY.y] != wall) && (moveRoll == 2))
            {
                if ((EnemyXY.y == PlayerXY.y))// && (EnemyXY.x - 1 != PlayerXY.x))
                {
                    health -= 1;
                }
                else
                {
                    EnemyXY.x -= 1;
                }
            }
            if ((map[EnemyXY.x + 1, EnemyXY.y] != wall) && (moveRoll == 3))
            {
                if ((EnemyXY.y == PlayerXY.y))// && (EnemyXY.x + 1 != PlayerXY.x))
                {
                    health -= 1;
                }
                else
                {
                    EnemyXY.x += 1;
                }
            }
        }
        static void PlayerDeath()
        {
            if (health <= 0)
            {
                gameOver = true;
            }
        }
        static void EnemyDeath()
        {
            if (eHealth <= 0)
            {
                enemyAlive = false;
            }
        }
    }
}