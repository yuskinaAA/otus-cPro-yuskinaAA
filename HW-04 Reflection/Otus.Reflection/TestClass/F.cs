using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Otus.HW.Reflections
{
    /// <summary>
    /// Определение класса //class F { int i1, i2, i3, i4, i5; Get() => new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 }; }
    /// </summary>
    public class F
    {
        private int i1;
        public int i2;
        public int i3;
        public int i4;
        public int i5;
        public string i6;

        public int I1 { get; set; }
        public int I2 { get; set; }
        public int I3 { get; set; }
        public int I4 { get; set; }


        public static F Get() => new() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5, i6 = "T\"est"};

        public override string ToString()
        {
            return $"Class F: i1: {i1}, i2: {i2}, i3: {i3}, i4: {i4}, i5: {i5}, i6: {i6}, I1: {I1}, I2: {I2}, I3: {I3}, I4: {I4}";
        }

    }
}
