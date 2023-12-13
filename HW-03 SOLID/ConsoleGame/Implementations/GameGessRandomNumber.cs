using HWGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HWGame.Implementations
{
    public class GameGessRandomNumber : IGame
    {
        private readonly IGenerateRandomNumber _randomNumber;
        private readonly IGuesser _gesser;
        private readonly INumberValidator _validator;
        private readonly IWriter _writer;
        private readonly IReader _reader;

        public GameGessRandomNumber(
            IGenerateRandomNumber randomNumber, 
            IGuesser gesser, 
            INumberValidator validator,
            IWriter writer,
            IReader reader)
        {
            _randomNumber = randomNumber;
            _gesser = gesser;
            _validator = validator;
            _writer = writer;
            _reader = reader;
        }

        public void StartGame(int countTry,int minNum, int maxNum)
        {
            //установка рандомного числа
            var randomNumberValue = _randomNumber.Generate(minNum, maxNum);

            //начинаем игру
            _writer.WriteLine("Предлагаю вам поиграть в игру. Правила очень просты:");
            _writer.WriteLine($"Я загадаю число от {minNum} до {maxNum}, у вас будет {countTry} попытки для того чтобы отгадать число.");

            for (var i = 0; i < countTry; i++)
            {
                _writer.Write("Введите число: ");
                var numToGess = _reader.ReadLine();
                if (!_validator.IsValidNumber(numToGess))
                {
                    _writer.WriteLine("Вы ввели не число!");
                    continue;
                }

                if (isGuessed(int.Parse(numToGess), randomNumberValue))
                    return;
               
            }

            _writer.WriteLine($"К сожалению вы проиграли. Мое число было {randomNumberValue}!");
        }

        public bool isGuessed(int numToGess, int randomNumberValue)
        {
            switch (_gesser.ProcessGuess(numToGess, randomNumberValue))
            {
                case HWGameResult.Less:
                    {
                        _writer.WriteLine("Загаданное число больше");
                        return false;
                    }
                case HWGameResult.More:
                    {
                        _writer.WriteLine("Загаданное число меньше");
                        return false;
                    }
                case HWGameResult.Equal:
                    {
                        _writer.WriteLine("Вы угадали!");
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }

        }
    }
}
