using Sandbox.PolymorphicSerialization.Animals.Cats;
using Sandbox.PolymorphicSerialization.Animals.Dogs;
using Sandbox.PolymorphicSerialization.Common;
using Sandbox.PolymorphicSerialization.Homes;

namespace Sandbox.PolymorphicSerialization.Tests;

public class HomeTests
{
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
}