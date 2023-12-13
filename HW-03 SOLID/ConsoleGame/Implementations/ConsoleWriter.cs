using HWGame.Interfaces;
using System;

namespace HWGame.Implementations
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string data)
        {
            Console.Write(data);
        }

        public void WriteLine(string data)
        {
            Console.WriteLine(data);
        }
    }
}