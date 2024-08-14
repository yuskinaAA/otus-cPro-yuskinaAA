using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.HW.DelegatesEvents.Files
{
    /// <summary>
    /// FileArgs – будет содержать имя файла и наследоваться от EventArgs
    /// </summary>
    public class FileArgs : EventArgs
    {
        public string FileName {get; set;}

        public FileArgs(string fileName)
        {
            FileName = fileName;
        }
    }
}
