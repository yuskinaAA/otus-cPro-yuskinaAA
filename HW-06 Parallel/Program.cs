using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HW_06_Parallel
{
    /*
     
     Task: Параллельное считывание файлов
     Цель: Студент сделает запуск тасок в параллель, 
           тем самым обретя базовые навыки работы с тасками, 
           что необходимо в повседневной работе C#-программиста
    Описание/Пошаговая инструкция выполнения домашнего задания:
    1. Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task).
    2. Написать функцию, принимающую в качестве аргумента путь к папке. 
       Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них.
    3. Замерьте время выполнения кода (класс Stopwatch).

     */

    public class Program
    {
        static async Task Main(string[] args)
        {
            //1. Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task).
            var file1 = @"C:\Users\User-N\OTUS\File1.txt";
            var file2 = @"C:\Users\User-N\OTUS\File2.txt";
            var file3 = @"C:\Users\User-N\OTUS\File3.txt";
            string[] files = { file1, file2, file3 };

            var sw = new Stopwatch();
            sw.Start();
            var allTasksExample1 = await ReadFiles(files, CountSpaceInFile);
            sw.Stop();
            Console.WriteLine($"Общее количество пробелов в файлах {allTasksExample1.Sum()}, время выполнения {sw.ElapsedMilliseconds} мс");

            //2 Написать функцию, принимающую в качестве аргумента путь к папке. Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них.
            sw.Restart();
            var allTasksExample2 = await ReadAllFilesFromPath(@"C:\Users\User-N\OTUS\", CountSpaceInFile);
            sw.Stop();
            Console.WriteLine($"Общее количество пробелов в файлах {allTasksExample2.Sum()}, время выполнения {sw.ElapsedMilliseconds} мс");
        }

        /// <summary>
        /// Метод считывает параллельно файлы, выполняя определенное действие
        /// </summary>
        /// <param name="files"></param>
        /// <param name="doAction"></param>
        /// <returns></returns>
        public static async Task<List<int>> ReadFiles(string[] files, Func<string, Task<int>> doAction)
        {
            var tasks = new List<Task<int>>();
            foreach (var file in files)
            {
                tasks.Add(doAction(file));
            }
            int[] taskResults = await Task.WhenAll(tasks);

            return taskResults.ToList();
        }

        /// <summary>
        /// Метод подсчитывает количество пробелов в переданном файле
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static async Task<int> CountSpaceInFile(string file)
        {
            if (File.Exists(file))
            {
                FileStream fileStream = File.OpenRead(file);
                var text = await File.ReadAllTextAsync(file);
                var cnt = text.Count(c => c.Equals(' '));

                return cnt;
            }

            return 0;
        }

        /// <summary>
        /// Метод находит все файлы в каталоге, и выполняет с ними определенное действие
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<List<int>> ReadAllFilesFromPath(string path, Func<string,Task<int>> doAction)
        {
            if (!Path.Exists(path))
            {
                return new List<int>();
            }
            var files = Directory.GetFiles(path);
            var tasks = new List<Task<int>>();

            foreach (var file in files)
            {
                tasks.Add(doAction(file));
            }

            var allTasks = await Task.WhenAll(tasks);

            return allTasks.ToList();
        }
    }
}
 