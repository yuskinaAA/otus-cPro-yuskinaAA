namespace HW_08_Prototype.Cosmetic;

/// <summary>
/// Базовый класс - косметика
/// </summary>
public abstract class CosmeticProduct : IMyCloneable<CosmeticProduct>, ICloneable
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }

    /// <summary>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="brand"></param>
    /// <param name="price"></param>
    protected CosmeticProduct(string name, string brand, decimal price)
    {
        Name = name;
        Brand = brand;
        Price = price;
    }

    /// <summary>
    /// </summary>
    /// <param name="other"></param>
    protected CosmeticProduct(CosmeticProduct other)
    {
        Name = other.Name;
        Brand = other.Brand;
        Price = other.Price;
    }

    public virtual object Clone()
    {
        return MyClone();
    }

    public abstract CosmeticProduct MyClone();

    public abstract void GetInfo();
}
