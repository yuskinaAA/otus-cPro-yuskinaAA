﻿using HWGame.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HWGame
{
    internal class Program
    {
        /*
        На примере реализации игры «Угадай число» продемонстрировать практическое применение SOLID принципов.
        Программа рандомно генерирует число, пользователь должен угадать это число. 
        При каждом вводе числа программа пишет больше или меньше отгадываемого. 
        Кол-во попыток отгадывания и диапазон чисел должен задаваться из настроек.
        В отчёте написать, что именно сделано по каждому принципу.

        1. Принцип единственной ответственности (Single Responsibility Principle - SRP): 
            - Класс "NumberGuesser" отвечает за процесс отгадывания числа.
            - Класс "GenerateRandomNumber" отвечает за генерацию случайного числа.
            - Класс "NumberValidator" отвечает за проверку правильности введенных пользователем чисел.

        2. Принцип открытости/закрытости (Open/Closed Principle - OCP):
            Не совсем уверенна, что реализовала это, но возможно это объяснение устроит
            - Например, можно изменить правила игры без изменения класса "GameGessRandomNumber", 
              достаточно написать новый класс, который будет отвечать за правила

        3. Принцип подстановки Барбары Лисков (Liskov Substitution Principle - LSP):
            - Например, можно использовать разные алгоритмы генерации чисел ("GenerateRandomNumber") 
              и валидацию числа ("NumberValidator")

        4. Принцип разделения интерфейса (Interface Segregation Principle - ISP):
            - Например, использование отдельного интерфейса для генерации случайных чисел, интерфейс который отгадывает число, 
              валидация числа.

        5. Принцип инверсии зависимостей (Dependency Inversion Principle - DIP):
            - Например, в классе ConsoleGameGessRandomNumber используется интерфейс IGenerateRandomNumber

        */
        static void Main(string[] args)
        {
            var consoleGameGess = new GameGessRandomNumber(
                new GenerateRandomNumber(), 
                new NumberGuesser(), 
                new NumberValidator(),
                new ConsoleWriter(),
                new ConsoleReader()
                );
            
            consoleGameGess.StartGame(3,1,1);
            Console.ReadLine();
        }
            
    }
}
