using HWGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HWGame.Implementations
{
    internal class NumberValidator : INumberValidator
    {
        public bool IsValidNumber(string str)
        {
            int num;
            return !string.IsNullOrEmpty(str) && int.TryParse(str, out num);
        }
    }
}
