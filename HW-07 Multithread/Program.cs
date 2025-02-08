using System.Diagnostics;

namespace HW07___Multithread
{
    public class Program
    {
        /*
        Описание/Пошаговая инструкция выполнения домашнего задания:
        1. Напишите вычисление суммы элементов массива интов:
        Обычное
        Параллельное (для реализации использовать Thread, например List)
        Параллельное с помощью LINQ
        2.Замерьте время выполнения для 100 000, 1 000 000 и 10 000 000
        3.Укажите в таблице результаты замеров, указав:
            Окружение(характеристики компьютера и ОС)
            Время выполнения последовательного вычисления
            Время выполнения параллельного вычисления
            Время выполнения LINQ
        */

        public static void Main(string[] args)
        {
            Console.WriteLine("Запускаем тесты по многопоточности!");
            Console.WriteLine();
            PrintInfoSystem();
            var sw = new Stopwatch();
            long[] lengthsOfArray = [100_000, 1_000_000, 10_000_000, 100000000,15,100];
            var cntThread = 5;
            var widthTable = 115;
            Console.WriteLine("-".PadLeft(widthTable, '-'));
            Console.WriteLine("{0,14} |{1,15} |{2,18} |{3,15} |{4,18} |{5,10} |{6,10}",
                "Размер массива", "Послед. сумма", "Послед. время (мс)", "Парал. сумма", "Парал. время (мс)", "LINQ сумма", "LINQ время (мс)");
            Console.WriteLine("-".PadLeft(widthTable, '-'));

            foreach (var lengthOfArray in lengthsOfArray)
            {
                int[] ints = new int[lengthOfArray];
                FullArrayWithRandom(ref ints);
                //1.1.вычисление суммы элементов массива интов.Обычное
                sw.Restart();
                long seqCalcSum = RegularCalcSumArrayElements(ints);
                sw.Stop();
                var seqCalcTime = sw.ElapsedMilliseconds;

                //1.2.вычисление суммы элементов массива интов.Параллельное
                sw.Restart();
                var threadCalcSum = ParallelCalcSumArrayElements(ints, cntThread);
                sw.Stop();
                var threadCalcTime = sw.ElapsedMilliseconds;

                //1.3.вычисление суммы элементов массива интов.Параллельное с помощью LINQ
                sw.Restart();
                var linqCalcSum = ints.AsParallel().Sum(x => (long)x);
                sw.Stop();
                var linqCalcTime = sw.ElapsedMilliseconds;

                Console.WriteLine("{0,14} |{1,15} |{2,18} |{3,15} |{4,18} |{5,10} |{6,10}",
                lengthOfArray, seqCalcSum, seqCalcTime, threadCalcSum, threadCalcTime, linqCalcSum, linqCalcTime);

                Console.WriteLine("-".PadLeft(widthTable, '-'));
            }
        }

        public static void PrintInfoSystem()
        {
            Console.WriteLine("Характеристики компьютера и ОС:");
            Console.WriteLine("   ОС: {0}", Environment.OSVersion.VersionString);
            Console.WriteLine("   Процессор, количество ядер: {0}", Environment.ProcessorCount);
            Console.WriteLine("   ОП: 15, 6 ГБ");
        }

        public static long ParallelCalcSumArrayElements(int[] intsArray, int cntThread)
        {
            List<Thread> threads = new List<Thread>();
            List<long> sumResults = new List<long>();
            //количество элементов для каждого потока
            var cntElemForEachThread = intsArray.Length / cntThread;
            long totalResult = 0;
            //начинаем запускать потоки
            for (var i = 0; i < cntThread; i++)
            {
                //сдвигаемся по массиву
                var from = i * cntElemForEachThread;
                var to = (i == cntThread - 1) ? intsArray.Length : from + cntElemForEachThread;
                Thread thred = new Thread(() =>
                {
                   var sum = RegularCalcSumArrayElementsFromTo(intsArray, from, to);
                    sumResults.Add(sum);
                });
                thred.Start();
                threads.Add(thred);
            }
            //ждем завершения всех потоков
            foreach (var thread in threads)
            {
                thread.Join();
            }
            foreach (var result in sumResults)
            {
                totalResult += result;
            }
            
            return totalResult;
        }

        /// <summary>
        /// Обычный подсчет суммы в массиве
        /// </summary>
        /// <param name="arrayLength"></param>
        /// <returns></returns>
        public static long RegularCalcSumArrayElements(int[] intsArray)
        {
            long sum = 0;
            for (long i = 0; i < intsArray.Length; i++) 
            {
                sum += (long)intsArray[i];
            }

            return sum;
        }

        /// <summary>
        /// Обычный подсчет суммы в массиве с дополнительными параметрами
        /// </summary>
        /// <param name="arrayLength"></param>
        /// <returns></returns>
        public static long RegularCalcSumArrayElementsFromTo(int[] intsArray, int from, int to)
        {
            var sum = 0;
            for (int i = from; i < to; i++)
            {
                sum += intsArray[i];
            }

            return sum;
        }

        /// <summary>
        /// заполняет массив случайными значениями
        /// </summary>
        /// <param name="intArray"></param>
        /// <returns></returns>
        public static void FullArrayWithRandom(ref int[] intArray)
        {
            Random random = new Random();
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = random.Next(0, 100);
            }
        }
    }
}
