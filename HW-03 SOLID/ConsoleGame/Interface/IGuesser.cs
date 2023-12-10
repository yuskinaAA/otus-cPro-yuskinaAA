using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interface
{
    public interface IGuesser
    {
        bool ProcessGuess(int guess, int targetNumber);
    }
}
