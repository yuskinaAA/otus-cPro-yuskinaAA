namespace HW_08_Prototype.Cosmetic;

/// <summary>
/// Класс для декоративной косметики
/// </summary>
public class MakeupProduct : CosmeticProduct
{
    public string Color { get; set; }

    public MakeupProduct(string name, string brand, decimal price, string color) : base(name, brand, price)
    {
        Color = color;
    }

    /// <summary>
    /// </summary>
    /// <param name="other"></param>
    protected MakeupProduct(MakeupProduct other) : base(other)
    {
        Color = other.Color;
    }

    /// <summary>
    /// Реализация IMyCloneable
    /// </summary>
    /// <returns></returns>
    public override MakeupProduct MyClone()
    {
        return new MakeupProduct(this);
    }

    public override void GetInfo()
    {
        Console.WriteLine($"{Name}, {Brand}, {Price}, {Color}");
    }
}
