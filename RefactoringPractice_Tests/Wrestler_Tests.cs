namespace RefactoringPractice_Tests;

using System.Collections.Generic;
using Xunit;
using RefactoringPractice;

public class Wrestler_Tests
{
    [Fact]
    public void ConstructorSetsNameCorrectly()
    {
        // Arrange
        string expectedName = "W. L. \"Happy\" Rose";

        // Act
        Wrestler wrestler = CreateTestWrestler(expectedName, "Test Catchphrase");

        // Assert
        Assert.Equal(expectedName, wrestler.Name);
    }

    [Fact]
    public void ConstructorSetsCatchphraseCorrectly()
    {
        // Arrange
        string expectedCatchphrase = "You were meant to be watching him!";

        // Act
        Wrestler wrestler = CreateTestWrestler("Test Name", expectedCatchphrase);

        // Assert
        Assert.Equal(expectedCatchphrase, wrestler.Catchphrase);
    }

    [Fact]
    public void ConstructorSetsMovesCorrectly()
    {
        // Arrange
        List<string> expectedMoves = new List<string> { "Elbow Smash", "Leg Lariat", "Heart Punch", "Catching Hip Toss" };

        // Act
        Wrestler wrestler = CreateTestWrestler("Test Name", "Test Catchphrase", expectedMoves);

        // Assert
        Assert.Equal(expectedMoves, wrestler.Moves);
    }

    [Fact]
    public void ConstructorSetsBreedCorrectly()
    {
        // Arrange
        string expectedBreed = "Pug";

        // Act
        Wrestler wrestler = CreateTestWrestler("Test Name", "Test Catchphrase", breed: expectedBreed);

        // Assert
        Assert.Equal(expectedBreed, wrestler.Breed);
    }

    [Fact]
    public void ConstructorSetsWrestlerNameCorrectly()
    {
        // Arrange
        string expectedWrestlerName = "The Snorting Nightmare";

        // Act
        Wrestler wrestler = CreateTestWrestler("Test Name", "Test Catchphrase", wrestlerName: expectedWrestlerName);

        // Assert
        Assert.Equal(expectedWrestlerName, wrestler.WrestlerName);
    }

    [Fact]
    public void ConstructorSetsDescriptionCorrectly()
    {
        // Arrange
        string expectedDescription = "Gasping for air between devastating strikes.";

        // Act
        Wrestler wrestler = CreateTestWrestler("Test Name", "Test Catchphrase", description: expectedDescription);

        // Assert
        Assert.Equal(expectedDescription, wrestler.Description);
    }

    [Fact]
    public void MovesListIsNotNull()
    {
        // Act
        Wrestler wrestler = CreateTestWrestler("Test Name", "Test Catchphrase");

        // Assert
        Assert.NotNull(wrestler.Moves);
    }

    [Fact]
    public void MovesListHasFourElements()
    {
        // Arrange
        List<string> expectedMoves = new List<string> { "Move 1", "Move 2", "Move 3", "Move 4" };

        // Act
        Wrestler wrestler = CreateTestWrestler("Test Name", "Test Catchphrase", expectedMoves);

        // Assert
        Assert.Equal(4, wrestler.Moves.Count);
    }

    private Wrestler CreateTestWrestler(
        string name, string catchphrase,
        List<string> moves = null, 
        string breed = "Pug", 
        string wrestlerName = "The Snorting Nightmare", 
        string description = "Gasping for air between devastating strikes.")
    {
        moves ??= new List<string> { "Elbow Smash", "Leg Lariat", "Heart Punch", "Catching Hip Toss" };
        BreedInfo breedInfo = new BreedInfo(breed, wrestlerName, description);
        return new Wrestler(name, catchphrase, moves, breedInfo);
    }
}
