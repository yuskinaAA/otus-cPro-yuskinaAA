using ConsoleApp1.Interface;
using HWGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Imlementations
{
    public class NumberGuesser : IGuesser
    {
        public bool ProcessGuess(int guess, int targetNumber)
        {
            if (guess < targetNumber)
            {
                Console.WriteLine("Загаданное число больше");
            }
            else if (guess > targetNumber)
            {
                Console.WriteLine("Загаданное число меньше");
            }
            else
            {
                Console.WriteLine("Вы угадали!");

                return true;
            }

            return false;
        }
    }
}
