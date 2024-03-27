# sandbox-polymorphic-serialization

Checking out (de)serialisation of a collection of types which share an interface using System.Text.Json

```csharp
public record Home(
    RecordsSet<IAnimal> Animals
    );

[JsonDerivedType(typeof(Cat), nameof(Cat))]
[JsonDerivedType(typeof(Dog), nameof(Dog))]
public interface IAnimal
{
    string Name { get; }
}

public record Cat(
    string Name,
    bool WillEatYourFaceWhileYouSleep = false
    ) : IAnimal;

public record Dog(
    string Name,
    DogTrainingLevel? TrainingLevel = null
    ) : IAnimal;
```

*nb ```RecordsSet``` is a record type for a collection of things to all comparison by value

```csharp
[Fact]
public void Serialize()
{
    var home = Home.Empty with
    {
        Animals = [
            Cat.New("Arthur") with { WillEatYourFaceWhileYouSleep = true },
            Dog.New("Max") with { TrainingLevel = DogTrainingLevel.Basic }
            ]
    };

    var json = Json.Serialize(home);

    var result = Json.Deserialize<Home>(json);
    Assert.NotNull(result);
    Assert.Equal(home, result);
}
```