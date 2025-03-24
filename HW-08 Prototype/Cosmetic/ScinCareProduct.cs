namespace HW_08_Prototype.Cosmetic;

// Класс для продуктов по уходу за кожей
public class SkinCareProduct : CosmeticProduct
{
    /// <summary>
    /// Тип кожи
    /// </summary>
    public string SkinType { get; set; }

    public SkinCareProduct(string name, string brand, decimal price, string skinType) : base(name, brand, price)
    {
        SkinType = skinType;
    }

    protected SkinCareProduct(SkinCareProduct other) : base(other)
    {
        SkinType = other.SkinType;
    }

    /// <summary>
    /// Реализация IMyCloneable
    /// </summary>
    /// <returns></returns>
    public override SkinCareProduct MyClone()
    {
        return new SkinCareProduct(this);
    }

    public override void GetInfo()
    {
        Console.WriteLine($"{Name}, {Brand}, {Price}, {SkinType}");
    }

}
