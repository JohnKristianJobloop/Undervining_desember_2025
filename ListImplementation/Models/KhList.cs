using System;
using ListImplementation.Interfaces;

namespace ListImplementation.Models;

public class KhList<T> : IKhList<T> where T: IComparable<T>
{
    internal T[] _values = [];

    internal int _capacity => _values.Length;

    internal int _growthFactor => 1;

    internal int _currentLastAvailableIndexOfValues = 0;

    private void _growUnderlyingArray()
    {
        T[] newArray = new T[_capacity + _growthFactor];
        _values = [.. newArray.Select((_, i) => i < _capacity && _values[i] is not null ? _values[i] : default!)];
    }

    public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Add(T? data)
    {
        if (data is null) return;
        if (_currentLastAvailableIndexOfValues >= _capacity)
        {
            _growUnderlyingArray();
        }
        _values[_currentLastAvailableIndexOfValues] = data;
        _currentLastAvailableIndexOfValues++;
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

    public void Change(T originalItem, Func<T, T> functionToChangeSomeData)
    {
        var found = _values.FirstOrDefault(value => value.Equals(originalItem));
        if (found is null) return;

        var index = _values.IndexOf(found);
        _values[index] = functionToChangeSomeData(found);
    }

    public T? Remove(T dataToBeRemoved)
    {
        var last = _values.Last();
       if (dataToBeRemoved.Equals(last))
        {
            _currentLastAvailableIndexOfValues--;
            return last;
        }
        var found = _values.FirstOrDefault(value => value.Equals(dataToBeRemoved));
        if (found is null) return default;
        var indexOfFound = _values.IndexOf(found);
        var result = new T[_currentLastAvailableIndexOfValues -1];
        _values.AsSpan(0, indexOfFound).CopyTo(result);
        _values.AsSpan(indexOfFound + 1, _currentLastAvailableIndexOfValues-1).CopyTo(result);
        _values = result;
        return found;
    }

    public T? Remove(Func<T, bool> functionToFindMatches)
    {
        throw new NotImplementedException();
    }
}
