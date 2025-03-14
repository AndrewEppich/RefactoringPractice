namespace RefactoringPractice_Tests;

using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using RefactoringPractice;

[Collection("FileAccessTests")]
public class WrestlerGeneratorTests : IDisposable
{
    private readonly string namesFile = "names.txt";
    private readonly string catchphrasesFile = "phrases.txt";
    private readonly string movesFile = "moves.txt";
    private readonly string breedsFile = "breeds.txt";
    private readonly List<string> originalNames;
    private readonly List<string> originalCatchphrases;
    private readonly List<string> originalMoves;
    private readonly List<string> originalBreeds;

    public WrestlerGeneratorTests()
    {
        // Backup existing files
        originalNames = BackupFile(namesFile);
        originalCatchphrases = BackupFile(catchphrasesFile);
        originalMoves = BackupFile(movesFile);
        originalBreeds = BackupFile(breedsFile);

        // Write controlled test data
        File.WriteAllLines(namesFile, new List<string>
        {
            "W. L. \"Happy\" Rose",
            "Wicked K. H. Arnold",
            "\"Decay\" Rivera"
        });

        File.WriteAllLines(catchphrasesFile, new List<string>
        {
            "You were meant to be watching him!",
            "Don't be scared. I just need you to come with me for a minute."
        });

        File.WriteAllLines(movesFile, new List<string>
        {
            "Elbow smash",
            "Springboard bulldog",
            "Leg lariat",
            "Double missile dropkick",
            "Heart Punch",
            "Catching hip toss"
        });

        File.WriteAllLines(breedsFile, new List<string>
        {
            "Pug; The Snorting Nightmare; Gasping for air between devastating strikes.",
            "Dachshund; The Weiner Taker; Masters of the **low** blow.",
            "Chihuahua; The Atomic Ankle Biter; Fast, furious, and yappy as hell.",
            "Pomeranian; The Fluffy Fireball; Cute but explosive—one wrong move and BOOM.",
            "Yorkshire Terrier; The Yorkie Yanker; Bites, yanks, and throws down with reckless abandon."
        });
    }

    [Fact]
    public void GenerateWrestlerReturnsNonNullWrestler()
    {
        WrestlerGenerator generator = new WrestlerGenerator();
        Wrestler wrestler = generator.GenerateWrestler();
        Assert.NotNull(wrestler);
    }

    [Fact]
    public void GenerateWrestlerAssignsNonEmptyName()
    {
        WrestlerGenerator generator = new WrestlerGenerator();
        Wrestler wrestler = generator.GenerateWrestler();
        Assert.False(string.IsNullOrWhiteSpace(wrestler.Name));
    }

    [Fact]
    public void GenerateWrestlerAssignsNonEmptyCatchphrase()
    {
        WrestlerGenerator generator = new WrestlerGenerator();
        Wrestler wrestler = generator.GenerateWrestler();
        Assert.False(string.IsNullOrWhiteSpace(wrestler.Catchphrase));
    }

    [Fact]
    public void GenerateWrestlerAssignsExactlyFourMoves()
    {
        WrestlerGenerator generator = new WrestlerGenerator();
        Wrestler wrestler = generator.GenerateWrestler();
        Assert.Equal(4, wrestler.Moves.Count);
    }

    [Fact]
    public void GenerateWrestlerAssignsUniqueMoves()
    {
        WrestlerGenerator generator = new WrestlerGenerator();
        Wrestler wrestler = generator.GenerateWrestler();
        Assert.Equal(wrestler.Moves.Count, new HashSet<string>(wrestler.Moves).Count);
    }

    [Fact]
    public void GenerateWrestlerAssignsValidMovesFromFile()
    {
        WrestlerGenerator generator = new WrestlerGenerator();
        List<string> allMoves = new List<string>(File.ReadAllLines(movesFile));
        Wrestler wrestler = generator.GenerateWrestler();
        Assert.All(wrestler.Moves, move => Assert.Contains(move, allMoves));
    }

    [Fact]
    public void GenerateWrestlerAssignsNonEmptyBreed()
    {
        WrestlerGenerator generator = new WrestlerGenerator();
        Wrestler wrestler = generator.GenerateWrestler();
        Assert.False(string.IsNullOrWhiteSpace(wrestler.Breed));
    }

    [Fact]
    public void GenerateWrestlerAssignsNonEmptyWrestlerName()
    {
        WrestlerGenerator generator = new WrestlerGenerator();
        Wrestler wrestler = generator.GenerateWrestler();
        Assert.False(string.IsNullOrWhiteSpace(wrestler.WrestlerName));
    }

    [Fact]
    public void GenerateWrestlerAssignsNonEmptyDescription()
    {
        WrestlerGenerator generator = new WrestlerGenerator();
        Wrestler wrestler = generator.GenerateWrestler();
        Assert.False(string.IsNullOrWhiteSpace(wrestler.Description));
    }

    [Fact]
    public void GenerateWrestlerAssignsValidBreedFromFile()
    {
        WrestlerGenerator generator = new WrestlerGenerator();
        Wrestler wrestler = generator.GenerateWrestler();

        List<string> allBreeds = new List<string>(File.ReadAllLines(breedsFile));
        string breedData = $"{wrestler.Breed}; {wrestler.WrestlerName}; {wrestler.Description}";
        Assert.Contains(breedData, allBreeds);
    }

    [Fact]
    public void GenerateNameEnsuresUniquenessUntilAllNamesUsed()
    {
        WrestlerGenerator generator = new WrestlerGenerator();
        HashSet<string> generatedNames = new HashSet<string>();

        for (int i = 0; i < 3; i++)
        {
            string name = generator.GenerateWrestler().Name;
            Assert.DoesNotContain(name, generatedNames);
            generatedNames.Add(name);
        }
    }

    [Fact]
    public void GenerateNameRepeatsAfterAllNamesUsed()
    {
        WrestlerGenerator generator = new WrestlerGenerator();
        HashSet<string> generatedNames = new HashSet<string>();

        for (int i = 0; i < 3; i++)
        {
            generatedNames.Add(generator.GenerateWrestler().Name);
        }

        string resetName = generator.GenerateWrestler().Name;
        Assert.Contains(resetName, generatedNames);
    }

    [Fact]
    public void GenerateCatchphraseReturnsValidCatchphraseFromFile()
    {
        WrestlerGenerator generator = new WrestlerGenerator();
        string catchphrase = generator.GenerateWrestler().Catchphrase;
        Assert.Contains(catchphrase, File.ReadAllLines(catchphrasesFile));
    }

    [Fact]
    public void GenerateBreedReturnsValidBreedFromFile()
    {
        WrestlerGenerator generator = new WrestlerGenerator();
        Wrestler wrestler = generator.GenerateWrestler();

        List<string> allBreeds = new List<string>();
        foreach (var line in File.ReadAllLines(breedsFile))
        {
            var parts = line.Split(';');
            if (parts.Length >= 3)
            {
                allBreeds.Add(parts[0].Trim());
            }
        }

        Assert.Contains(wrestler.Breed, allBreeds);
    }

    [Fact]
    public void ConstructorThrowsExceptionForMissingFile()
    {
        File.Delete(namesFile);
        Assert.Throws<FileNotFoundException>(() => new WrestlerGenerator());
    }

    [Fact]
    public void ConstructorThrowsExceptionForEmptyFile()
    {
        File.WriteAllText(namesFile, "");
        Assert.Throws<InvalidOperationException>(() => new WrestlerGenerator());
    }

    public void Dispose()
    {
        RestoreFile(namesFile, originalNames);
        RestoreFile(catchphrasesFile, originalCatchphrases);
        RestoreFile(movesFile, originalMoves);
        RestoreFile(breedsFile, originalBreeds);
    }

    private List<string> BackupFile(string filePath)
    {
        return File.Exists(filePath) ? new List<string>(File.ReadAllLines(filePath)) : new List<string>();
    }

    private void RestoreFile(string filePath, List<string> originalContent)
    {
        if (originalContent.Count > 0)
        {
            File.WriteAllLines(filePath, originalContent);
        }
        else if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}

