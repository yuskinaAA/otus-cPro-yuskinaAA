using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWGame.Imlementations
{
    internal class GenerateRandomNumber : IGenerateRandomNumber
    { 
        public int Generate(int minNum, int maxNum)
        {
            Random randomNum = new Random();

            return  randomNum.Next(minNum, maxNum);
        }
    }
}
