using System.Collections;

namespace UstaPlatform.Infrastructure.Collections;

public class Route : IEnumerable<(int X, int Y)>
{
    private readonly List<(int X, int Y)> _points = new();

    public void Add(int x, int y) => _points.Add((x, y));

    public IEnumerator<(int X, int Y)> GetEnumerator() => _points.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public int Count => _points.Count;
}