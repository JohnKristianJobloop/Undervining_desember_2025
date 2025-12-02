using System;
using ListImplementation.Interfaces;

namespace ListImplementation.Models;

public class KhList<T> : IKhList<T>
{
    internal T[] _values = [];

    internal int _capacity => _values.Length;

    internal int _growthFactor => 1;

    internal int _currentEndOfValue = 0;

    private void _growUnderlyingArray()
    {
        T[] newArray = new T[_capacity + _growthFactor];
        _values = [.. newArray.Select((_, i) => i < _capacity && _values[i] is not null ? _values[i] : default!)];
    }

    public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Add(T? data)
    {
        if (data is null) return;
        if (_currentEndOfValue >= _capacity)
        {
            _growUnderlyingArray();
        }
        _values[_currentEndOfValue] = data;
        _currentEndOfValue++;
        return;
    }

    public void Change(T changedData, int index)
    {
        throw new NotImplementedException();
    }

    public void Change(T changedData, T originalItem)
    {
        throw new NotImplementedException();
    }

    public void Change(Func<T, T> functionToChangeSomeData)
    {
        throw new NotImplementedException();
    }

    public T? Remove(T dataToBeRemoved)
    {
        throw new NotImplementedException();
    }

    public T? Remove(Func<T, bool> functionToFindMatches)
    {
        throw new NotImplementedException();
    }
}
