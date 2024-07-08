using UltimateOrb.Runtime.InteropServices;

namespace UltimateOrb.Runtime.InteropServices.Collections.Tests;

public class UnitTest1 {

    [Fact]
    public void ModifyValues_ShouldDoubleValues() {
        // Arrange
        var dictionary = new Dictionary<string, int> {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
        };

        // Act
        DictionariesMarshal.ForEachValue(dictionary, (ref int value) => value *= 2);

        // Assert
        Assert.Equal(2, dictionary["one"]);
        Assert.Equal(4, dictionary["two"]);
        Assert.Equal(6, dictionary["three"]);
        Assert.Equal(8, dictionary["four"]);
        Assert.Equal(10, dictionary["five"]);
        Assert.Equal(12, dictionary["six"]);
    }
}
