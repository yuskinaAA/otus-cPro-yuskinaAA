using Otus.HW.DelegatesEvents.Files;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Otus.HW.DelegatesEvents
{
    public class Program
    {
        public static void Main()
        {
            /*
             Выполнение п. 1
             Написать обобщённую функцию расширения, 
             находящую и возвращающую максимальный элемент коллекции.
             Функция должна принимать на вход делегат, 
             преобразующий входной тип в число для возможности поиска 
             максимального значения.
             public static T GetMax(this IEnumerable collection, Func<T, float> convertToNumber) where T : class;
            */
            var products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 125000.0f },
                new Product { Name = "Pen", Price = 35.0f },
                new Product { Name = "Eraser", Price = 25.25f }
            };

            var maxPrice = products.GetMax(item => item.Price);
            Console.WriteLine($"Max Price: {maxPrice.Price}");

            /*
            Выполнение п. 2-5
            */
            CancellationTokenSource cts = new CancellationTokenSource();
            FileSearchService fs = new FileSearchService(Directory.GetCurrentDirectory(), cts);
            fs.FileFound += DisplayMessage;
            fs.StartFileSearch();
            Console.WriteLine("I'm finished");
            Console.ReadLine();
        }

        public static void DisplayMessage(object sender, FileArgs e)
        {
            Console.WriteLine($"Found the file: {e.FileName}");
            var fs = sender as FileSearchService;
            //Выполняется какое-то условие
            if (e.FileName.Contains(".config"))
            {
                fs._cancelToken.Cancel();
                fs.FileFound -= DisplayMessage; 
            }
        }
    }
}
