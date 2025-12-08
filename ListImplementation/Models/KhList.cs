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

    public T this[int index] {
        get
        {
            if(index < 0 || index >= _currentLastAvailableIndexOfValues)
            {
                throw new IndexOutOfRangeException();
            }
            return _values[index];
        } 
        set
        {
            if(index < 0 || index >= _currentLastAvailableIndexOfValues)
            {
                throw new IndexOutOfRangeException();
            }
            _values[index] = value;
        }
    }

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

    // change the first instance of incomming data by it's index
    public void Change(T changedData, int index)
    {
        if(index < 0 || index >= _currentLastAvailableIndexOfValues)
        {
            throw new IndexOutOfRangeException("");
        }

        _values[index] = changedData;
    }
    
    public void Change(T changedData, T originalItem)
    {
        var index = FindIndex(originalItem);
        // if we find the last position(-1) we exit out/return
        if(index == -1)
        {
            return;
        }

        _values[index] = changedData;

    }

    public void Change(T originalItem, Func<T, T> functionToChangeSomeData)
    {
        // var found = _values.FirstOrDefault(value => value.Equals(originalItem));
        // if (found is null) return;

        // var index = IndexOf(found, -1);
        // _values[index] = functionToChangeSomeData(found);

        // sorry, try to utilize the helper method. - jm
        
        var getIndex = FindIndex(originalItem);
        if(getIndex == - 1)
        {
            return;
        }
        _values[getIndex] = functionToChangeSomeData(_values[getIndex]);
    }

    // public T? Remove(T dataToBeRemoved)
    // {
    //     var last = _values.Last();
    //    if (dataToBeRemoved.Equals(last))
    //     {
    //         _currentLastAvailableIndexOfValues--;
    //         return last;
    //     }
    //     var found = _values.FirstOrDefault(value => value.Equals(dataToBeRemoved));
    //     if (found is null) return default;
    //     var indexOfFound = _values.Where(_values[found]);
    //     var result = new T[_currentLastAvailableIndexOfValues -1];
    //     _values.AsSpan(0, indexOfFound).CopyTo(result);
    //     _values.AsSpan(indexOfFound + 1, _currentLastAvailableIndexOfValues-1).CopyTo(result);
    //     _values = result;
    //     return found;
    // }

    // basic implementation

    public T? Remove(T dataToBeRemoved)
    {
        var index = FindIndex(dataToBeRemoved);
        if(index == -1)
        {
            return default;
        }
        return RemoveAtInternal(index);
    }

    public T? Remove(Func<T, bool> functionToFindMatches)
    {
        for(int i = 0; i < _currentLastAvailableIndexOfValues; i++)
        {
            if (functionToFindMatches(_values[i]))
            {
                return RemoveAtInternal(i);
            }
        }
        return default;
    }

    // private helper method: FindIndex
    private int FindIndex(T item)
    {
        for(int i = 0; i < _currentLastAvailableIndexOfValues;i++)
        {
            if (_values[i].Equals(item))
            {
                return i;
            }
        }
        return -1;
    }

    // private helper method: RemoveAtInternal
    private T? RemoveAtInternal(int index)
    {
        T removed = _values[index]; // keep track of removed items

        for(int i = 0; i < _currentLastAvailableIndexOfValues - 1; i++)
        {
            _values[i] = _values[i + 1];
        }

        _currentLastAvailableIndexOfValues--;

        return removed;
    }
}
