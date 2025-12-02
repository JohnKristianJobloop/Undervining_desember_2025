using System;

namespace ListImplementation.Interfaces;

public interface IKhList<T>
{
    public void Add(T data);
    public T? Remove(T dataToBeRemoved);

    public T? Remove(Func<T, bool> functionToFindMatches);

    public void Change(T changedData, int index);
    
    public void Change(T changedData, T originalItem);

    public void Change(Func<T, T> functionToChangeSomeData);

    public T this[int index]{get;set;}
}
