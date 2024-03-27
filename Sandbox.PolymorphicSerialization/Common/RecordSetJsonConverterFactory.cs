using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox.PolymorphicSerialization.Homes;

public class RecordSetJsonConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(
        Type typeToConvert
        ) => typeToConvert.IsGenericType
            && typeToConvert.GetGenericTypeDefinition() == typeof(RecordsSet<>);

    public override JsonConverter? CreateConverter(
        Type typeToConvert,
        JsonSerializerOptions options
        ) => (JsonConverter)Activator
            .CreateInstance(
                typeof(RecordSetJsonConverter<>)
                    .MakeGenericType([typeToConvert.GetGenericArguments()[0]]),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: [],
                culture: null)!;
}
