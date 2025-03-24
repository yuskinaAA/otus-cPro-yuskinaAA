using HW_08_Prototype.Cosmetic;

public class Program
{

    /*
    Задание: 
    1. Придумать и создать 3-4 класса, которые как минимум дважды наследуются и написать краткое описание текстом.
    2. Создать свой дженерик интерфейс IMyCloneable для реализации шаблона "Прототип".
    3. Сделать возможность клонирования объекта для каждого из этих классов, используя вызовы родительских конструкторов.
    4. Составить тесты или написать программу для демонстрации функции клонирования.
    5. Добавить к каждому классу реализацию стандартного интерфейса ICloneable и реализовать его функционал через уже созданные методы.
    6. Написать вывод: какие преимущества и недостатки у каждого из интерфейсов: IMyCloneable и ICloneable.
    
    Реализация:
     Придуманы следующие классы: 
        CosmeticProduct - абстрактный класс косметики
            SkinCareProduct - класс для косметики по уходу за кожей
                CreamProduct - наследник SkinCareProduct, класс для кремов
            MakeupProduct - класс для декоративной косметики

     
     Преимущества и недостатки интерфейсов
     IMyCloneable
      + Позволяет возвращать конкретный тип (делает код более безопасным, читаемым)
      + Не нужно приводить типы вручную
      - Дополнительная реализация в каждом классе (требует самостоятельного поддержания)

     ICloneable
      + Унифицированный подход к клонированию объектов
      - Требует приведения типов

     */
    private static void Main(string[] args)
    {
        // Тесты
        var skincare = new SkinCareProduct("Moisturizer", "Nivea", 755, "All");
        var makeup = new MakeupProduct("Lipstick", "Maybelline", 1200, "Red");
        var cream = new CreamProduct("BB Cream", "CRM", 400, "Oily", "Medium");

        Console.WriteLine("-----------------------------------------------------");
        Console.Write("Original Skincare: ");
        skincare.GetInfo();
        Console.Write("Original Makeup: ");
        makeup.GetInfo();
        Console.Write("Original Cream: ");
        cream.GetInfo();

        Console.WriteLine("-----------------------------------------------------");

        // Клонирование через IMyClonable
        var skincareIMyClonable = skincare.MyClone();
        skincareIMyClonable.Price = 2000;

        var makeupIMyClonable = makeup.MyClone();
        makeupIMyClonable.Color = "Pink";

        var creamIMyClonable = cream.MyClone();
        creamIMyClonable.Coverage = "Sheer";

        Console.Write("Cloned Skincare by IMyCloneable: ");
        skincareIMyClonable.GetInfo();
        Console.Write("Cloned Makeup by IMyCloneable: ");
        makeupIMyClonable.GetInfo();
        Console.Write("Cloned Cream by IMyCloneable: ");
        creamIMyClonable.GetInfo();
        Console.WriteLine("-----------------------------------------------------");
        // Клонирование через ICloneable
        var skincareICloneable = (SkinCareProduct)skincare.Clone();
        skincareICloneable.Price = 1500;
        var makeupICloneable = (MakeupProduct)makeup.Clone();
        makeupICloneable.Color = "Brick red";
        var creamICloneable = (CreamProduct)cream.Clone();
        creamICloneable.Coverage = "Full";

        Console.Write("Cloned Skincare by ICloneable: ");
        skincareICloneable.GetInfo();
        Console.Write("Cloned Makeup by ICloneable: ");
        makeupICloneable.GetInfo();
        Console.Write($"Cloned Cream by ICloneable: ");
        creamICloneable.GetInfo();
        Console.WriteLine("-----------------------------------------------------");
    }
}