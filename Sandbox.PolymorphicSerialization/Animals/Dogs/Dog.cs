namespace Sandbox.PolymorphicSerialization.Animals.Dogs;

public record Dog(
    string Name,
    DogTrainingLevel? TrainingLevel = null
    ) : IAnimal
{
    public static readonly Dog Empty = new(default!);
    public static Dog New(string name) => new(name);
}
