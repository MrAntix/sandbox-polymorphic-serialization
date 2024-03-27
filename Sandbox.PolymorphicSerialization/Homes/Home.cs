using Sandbox.PolymorphicSerialization.Animals;

namespace Sandbox.PolymorphicSerialization.Homes;

public record Home(
    RecordsSet<IAnimal> Animals
    )
{
    public static readonly Home Empty = new(
        RecordsSet<IAnimal>.Empty
        );
}
