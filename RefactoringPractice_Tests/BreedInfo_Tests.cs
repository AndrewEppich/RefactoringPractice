namespace RefactoringPractice_Tests;

using Xunit;
using RefactoringPractice;

public class BreedInfo_Tests
{
    [Fact]
    public void ConstructorSetsBreedCorrectly()
    {
        // Arrange
        string expectedBreed = "Pug";
        
        // Act
        BreedInfo breedInfo = new BreedInfo(expectedBreed, "The Snorting Nightmare", "Gasping for air between devastating strikes.");

        // Assert
        Assert.Equal(expectedBreed, breedInfo.Breed);
    }

    [Fact]
    public void ConstructorSetsWrestlerNameCorrectly()
    {
        // Arrange
        string expectedWrestlerName = "The Snorting Nightmare";

        // Act
        BreedInfo breedInfo = new BreedInfo("Pug", expectedWrestlerName, "Gasping for air between devastating strikes.");

        // Assert
        Assert.Equal(expectedWrestlerName, breedInfo.WrestlerName);
    }

    [Fact]
    public void ConstructorSetsDescriptionCorrectly()
    {
        // Arrange
        string expectedDescription = "Gasping for air between devastating strikes.";

        // Act
        BreedInfo breedInfo = new BreedInfo("Pug", "The Snorting Nightmare", expectedDescription);

        // Assert
        Assert.Equal(expectedDescription, breedInfo.Description);
    }

    [Fact]
    public void TwoInstancesWithSameValuesAreNotSameObject()
    {
        // Arrange
        var breed1 = new BreedInfo("Pug", "The Snorting Nightmare", "Gasping for air between devastating strikes.");
        var breed2 = new BreedInfo("Pug", "The Snorting Nightmare", "Gasping for air between devastating strikes.");

        // Assert
        Assert.NotSame(breed1, breed2);
    }

    [Fact]
    public void TwoInstancesWithDifferentBreedsAreNotEqual()
    {
        // Arrange
        var breed1 = new BreedInfo("Pug", "The Snorting Nightmare", "Gasping for air between devastating strikes.");
        var breed2 = new BreedInfo("Dachshund", "The Weiner Taker", "Masters of the **low** blow.");

        // Assert
        Assert.NotEqual(breed1.Breed, breed2.Breed);
    }

    [Fact]
    public void TwoInstancesWithDifferentWrestlerNamesAreNotEqual()
    {
        // Arrange
        var breed1 = new BreedInfo("Pug", "The Snorting Nightmare", "Gasping for air between devastating strikes.");
        var breed2 = new BreedInfo("Pug", "The Growling Goblin", "Small, but never backs down.");

        // Assert
        Assert.NotEqual(breed1.WrestlerName, breed2.WrestlerName);
    }

    [Fact]
    public void TwoInstancesWithDifferentDescriptionsAreNotEqual()
    {
        // Arrange
        var breed1 = new BreedInfo("Pug", "The Snorting Nightmare", "Gasping for air between devastating strikes.");
        var breed2 = new BreedInfo("Pug", "The Snorting Nightmare", "A master of the sleeper hold—literally.");

        // Assert
        Assert.NotEqual(breed1.Description, breed2.Description);
    }
}

