namespace Sandbox.PolymorphicSerialization.Animals.Cats;

public record Cat(
    string Name,
    bool WillEatYourFaceWhileYouSleep = false
    ) : IAnimal
{
    public static readonly Cat Empty = new(default!);
    public static Cat New(string name) => new(name);
}