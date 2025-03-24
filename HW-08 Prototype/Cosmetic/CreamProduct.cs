namespace HW_08_Prototype.Cosmetic;

/// <summary>
/// Класс для крема. Ex: Тональный крем для лица
/// </summary>
public class CreamProduct : SkinCareProduct
{
    /// <summary>
    /// Способности продукта скрывать недостатки кожи
    /// </summary>
    public string Coverage { get; set; }

    /// <summary>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="brand"></param>
    /// <param name="price"></param>
    /// <param name="skinType"></param>
    /// <param name="coverage"></param>
    public CreamProduct(string name, string brand, decimal price, string skinType, string coverage) : base(name, brand, price, skinType)
    {
        Coverage = coverage;
    }

    protected CreamProduct(CreamProduct other) : base(other)
    {
        Coverage = other.Coverage;
    }

    /// <summary>
    /// Реализация IMyCloneable
    /// </summary>
    /// <returns></returns>
    public override CreamProduct MyClone()
    {
        return new CreamProduct(this);
    }

    public override void GetInfo()
    {
        Console.WriteLine($"{Name}, {Brand}, {Price}, {SkinType}, {Coverage}");
    }
}

