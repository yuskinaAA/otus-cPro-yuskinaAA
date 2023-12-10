using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Interface;

namespace HWGame
{
    public class ConsoleGameGessRandomNumber : IGame
    {
        //настройки-свойства
        public int CountTry { get; set; }
        public int MinNum { get; set; }
        public int MaxNum { get; set; }

        public IGenerateRandomNumber _randomNumber;
        public IGuesser _gesser;
        public INumberValidator _validator;

        public int randomNumberValue;

        public ConsoleGameGessRandomNumber(IGenerateRandomNumber randomNumber, IGuesser gesser, INumberValidator validator)
        {
            _randomNumber = randomNumber;
            _gesser = gesser;
            _validator = validator;
        }

        public void StartGame()
        {
            //установка рандомного числа
            randomNumberValue = _randomNumber.Generate(MinNum, MaxNum);

            //начинаем игру
            Console.WriteLine("Предлагаю вам поиграть в игру. Правила очень просты:");
            Console.WriteLine($"Я загадаю число от {MinNum} до {MaxNum}, у вас будет {CountTry} попытки для того чтобы отгадать число.");

            string numToGess;
            bool winner = false;

            int p = 1;

            while (p <= CountTry)
            {
                Console.WriteLine("Введите число");
                p++;
                numToGess = Console.ReadLine();
                if (_validator.IsValidNumber(numToGess))
                {
                    if (_gesser.ProcessGuess(int.Parse(numToGess), randomNumberValue))
                    {
                        winner = true;

                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели не число");
                    continue;
                }

            }

            if (!winner)
            {
                Console.WriteLine($"К сожалению вы проиграли. Мое число было {randomNumberValue}");
            }
        }
    }
}
