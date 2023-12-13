using HWGame.Implementations;
using System;

namespace HWGame.Implementations
{
    internal class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}