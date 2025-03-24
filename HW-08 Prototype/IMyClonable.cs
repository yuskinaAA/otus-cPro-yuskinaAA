namespace HW_08_Prototype;

public interface IMyCloneable<T> where T : class
{
    T MyClone();
}
