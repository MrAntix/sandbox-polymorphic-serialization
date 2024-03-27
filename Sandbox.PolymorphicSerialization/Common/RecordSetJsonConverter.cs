using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox.PolymorphicSerialization.Homes;

public class RecordSetJsonConverter<T> : JsonConverter<RecordsSet<T>>
{
    public override RecordsSet<T>? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
        )
    {
        var listConverter = (options.GetConverter(typeof(IEnumerable<T>)) as JsonConverter<IEnumerable<T>>)!;
        var list = listConverter.Read(ref reader, typeof(IEnumerable<T>), options);

        return list == null ? null : new RecordsSet<T>(list);
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecordsSet<T> value,
        JsonSerializerOptions options
        )
    {
        var listConverter = (options.GetConverter(typeof(IEnumerable<T>)) as JsonConverter<IEnumerable<T>>)!;
        listConverter.Write(writer, value, options);
    }
}