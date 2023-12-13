using HWGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWGame.Implementations
{
    public class NumberGuesser : IGuesser
    {
        public HWGameResult ProcessGuess(int guess, int targetNumber)
        {
            if (guess < targetNumber)
            {
                return HWGameResult.Less;
            }

            if (guess > targetNumber)
            {
                return HWGameResult.More;
            }

            return HWGameResult.Equal;
        }
    }
}
