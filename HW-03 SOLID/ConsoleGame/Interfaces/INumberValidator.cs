using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HWGame.Interfaces
{
    public interface INumberValidator
    {
        bool IsValidNumber(string str);
    }
}
