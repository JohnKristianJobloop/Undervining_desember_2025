using System;
using RepetisjonDag.Interfaces;

namespace RepetisjonDag.Models;

public class LD : ILD
{
    public int Distance(IEnumerable<char> a,IEnumerable<char> b)
    {
        if (a.Count() == 0) return b.Count();
        if (b.Count() == 0) return a.Count();

        if (a.First() == b.First()) return Distance(a.Skip(1), b.Skip(1));

        return 1 + Math.Min(
            Distance(a, b.Skip(1)),
            Math.Min(
                Distance(a.Skip(1), b),
                Distance(a.Skip(1), b.Skip(1))
            )
        );
    }
}
