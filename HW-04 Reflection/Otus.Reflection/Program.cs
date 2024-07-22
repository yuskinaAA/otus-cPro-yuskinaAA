#region
/*
Написать свой класс-сериализатор данных любого типа в формат CSV, сравнение его быстродействия с типовыми механизмами серализации.
Полезно для изучения возможностей Reflection, а может и для применения данного класса в будущем.
Описание/Пошаговая инструкция выполнения домашнего задания:
Основное задание:
1.Написать сериализацию свойств или полей класса в строку
2.Проверить на классе: class F { int i1, i2, i3, i4, i5; Get() => new F(){ i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 }; }
3.Замерить время до и после вызова функции (для большей точности можно сериализацию сделать в цикле 100-100000 раз)
4.Вывести в консоль полученную строку и разницу времен
5.Отправить в чат полученное время с указанием среды разработки и количества итераций
6.Замерить время еще раз и вывести в консоль сколько потребовалось времени на вывод текста в консоль
7.Провести сериализацию с помощью каких-нибудь стандартных механизмов (например в JSON)
8.И тоже посчитать время и прислать результат сравнения
9.Написать десериализацию/загрузку данных из строки (ini/csv-файла) в экземпляр любого класса
10.Замерить время на десериализацию
11.Общий результат прислать в чат с преподавателем в системе в таком виде:
Сериализуемый класс: class F { int i1, i2, i3, i4, i5; string i6;}
код сериализации-десериализации: ...
количество замеров: 100000 итераций
мой рефлекшен:
Время на сериализацию = 273 мс
Время на десериализацию = 365 мс
стандартный механизм (NewtonsoftJson):
Время на сериализацию = 896 мс
Время на десериализацию = 517 мс
*/
#endregion
// See https://aka.ms/new-console-template for more information
using Otus.HW.Reflections;
using System.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Text.Json;

Console.WriteLine("Hello, Let's start!");
int countIteration = 100000;
F f = F.Get();
Console.WriteLine(f.ToString());

//1.****************************
//Замерить время до и после вызова функции (для большей точности можно сериализацию сделать в цикле 100-100000 раз)
string serialObject = string.Empty;
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
CSVConverter converter = new CSVConverter();
for (int i = 1; i < countIteration; i++)
{
    serialObject = CSVConverter.SerializeObject(f);
}
stopwatch.Stop();
Console.WriteLine("Сериализовали в строку вида:");
Console.WriteLine(serialObject);
Console.WriteLine($"CSVConverter.Время затраченное на сериализацию в миллисекундах {stopwatch.ElapsedMilliseconds}");

//2.****************************
// Провести сериализацию с помощью каких-нибудь стандартных механизмов (например в JSON)
string json = string.Empty;
stopwatch.Restart(); 
for (int i = 0; i < countIteration; i++)
{
    json = JsonConvert.SerializeObject(f);
}
stopwatch.Stop();
Console.WriteLine("Сеарилизовали в json");
Console.WriteLine(json);
Console.WriteLine($"NewtonJson.Время затраченное на сериализацию в миллисекундах {stopwatch.ElapsedMilliseconds}");

//3.****************************
// Написать десериализацию/загрузку данных из строки в экземпляр любого класса
stopwatch.Restart();
for (int i = 0; i < countIteration; i++)
{
   F deserialObject = CSVConverter.DeserializeToObject<F>(serialObject);
}
stopwatch.Stop();
Console.WriteLine($"CSVConverter.Время затраченное на десериализацию в миллисекундах {stopwatch.ElapsedMilliseconds}");

stopwatch.Restart();
for (int i = 0; i < countIteration; i++)
{
    F deserialObject = JsonConvert.DeserializeObject<F>(json);
}
stopwatch.Stop();
Console.WriteLine($"NewtonJson. Время затраченное на десериализацию в миллисекундах {stopwatch.ElapsedMilliseconds}");