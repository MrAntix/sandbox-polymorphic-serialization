using Sandbox.PolymorphicSerialization.Animals.Cats;
using Sandbox.PolymorphicSerialization.Animals.Dogs;
using System.Text.Json.Serialization;

namespace Sandbox.PolymorphicSerialization.Animals;

[JsonDerivedType(typeof(Cat), nameof(Cat))]
[JsonDerivedType(typeof(Dog), nameof(Dog))]
public interface IAnimal
{
    string Name { get; }
}
