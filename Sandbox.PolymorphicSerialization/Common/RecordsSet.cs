using System.Collections;
using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace Sandbox.PolymorphicSerialization.Homes;

[JsonConverter(typeof(RecordSetJsonConverterFactory))]
public record RecordsSet<T> :
    IEnumerable<T>, IEquatable<RecordsSet<T>>
{
    public static readonly RecordsSet<T> Empty = new(ImmutableList<T>.Empty);

    readonly ImmutableList<T> _items;

    public RecordsSet() => _items = [];
    public RecordsSet(IEnumerable<T> items) => _items = items.ToImmutableList();

    public int Count => _items.Count;
    public RecordsSet<T> Add(T item) => new(_items.Add(item));
    public RecordsSet<T> Remove(T item) => new(_items.Remove(item));

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 19;
            foreach (var item in _items)
            {
                hash = hash * 31 + (item == null ? 0 : item.GetHashCode());
            }
            return hash;
        }
    }

    bool IEquatable<RecordsSet<T>>.Equals(RecordsSet<T>? other)
        => other != null &&
               (_items.Count == other._items.Count) &&
               !_items.Except(other._items).Any();

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => ((IEnumerable<T>)_items).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_items).GetEnumerator();
}
