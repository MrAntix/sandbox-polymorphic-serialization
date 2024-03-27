using System.Text.Json;

namespace Sandbox.PolymorphicSerialization.Common;

public static class Json
{
    public static readonly JsonSerializerOptions SerializerOptions
        = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

    public static T? Deserialize<T>(string? value)
        => value is null
            ? default
            : JsonSerializer.Deserialize<T>(value, SerializerOptions);

    public static string Serialize(object? value)
        => JsonSerializer.Serialize(value, SerializerOptions);

    public static Deferred DeferSerialize(object? value)
        => new(value);

    public sealed record Deferred(object? Value)
    {
        public override string ToString()
            => Serialize(Value);
    }
}