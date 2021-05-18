using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallMania
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new Game();
            g.Start();
            g.PrintMessage("Press 'Enter' to quit.");
            Console.ReadLine();
        }
    }

    class Game
    {
        private bool playing;
        private int score = 0;
        private int newScore;
        public void Start()
        {
            playing = true;
            PrintMessage("Welcome to ball mania!\n");
            while (playing)
            {
                PrintMessage("Press a key to shoot a basket, press e to exit.\n");
                PrintScore();
                ConsoleKeyInfo key = Console.ReadKey(true);
                GetKeyPressed(key);
            }
            PrintMessage("Thank you for playing. Your final score is " + score);
        }

        private void AddToScore(int add)
        {
            score += add;
        }

        private void PrintScore()
        {
            Console.WriteLine("Your current score is: " + score + "\n");
        }

        public void PrintMessage(string mes)
        {
            Console.WriteLine(mes);
        }

        private void GetKeyPressed(ConsoleKeyInfo key)
        {
            Console.Clear();
            if (key.KeyChar == 'e')
            {
                playing = false;
            }
            else
            {
                newScore = ShootBasket();
                if (newScore == 0)
                {
                    PrintMessage("You missed, try again.\n");
                }
                else
                {
                    PrintMessage("You scored " + newScore + " points.\n");
                }
                AddToScore(newScore);
            }
        }

        private int ShootBasket()
        {
            Random rnd = new Random();
            int result = rnd.Next(0, 4);
            return result;
        }
    }
}
