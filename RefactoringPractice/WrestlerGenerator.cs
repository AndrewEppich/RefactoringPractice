namespace RefactoringPractice;

using System;
using System.Collections.Generic;
using System.IO;

public class WrestlerGenerator
{
    public List<string> Names = new List<string>();
    public List<string> Catchphrases = new List<string>();
    public List<string> Moves = new List<string>();
    public List<BreedInfo> Breeds;
    public List<string> UsedNames = new List<string>();
    public Random Random = new Random();
    
    public string NamesFilename = "names.txt";
    public string CatchphrasesFilename = "phrases.txt";
    public string MovesFilename = "moves.txt";
    public string BreedsFilename = "breeds.txt";
    
    public FileLoader FileLoader;

  
    public WrestlerGenerator()
    {
        FileLoader = new FileLoader();
        Names = FileLoader.LoadFile(NamesFilename, Names);
        Catchphrases = FileLoader.LoadFile(CatchphrasesFilename, Catchphrases);
        Moves = FileLoader.LoadFile(MovesFilename, Moves);
        Breeds = FileLoader.LoadBreedInfo();
        
        
        
        if (Names.Count == 0 || Catchphrases.Count == 0 || Moves.Count < 4 || Breeds.Count == 0)
            throw new InvalidOperationException("Files cannot be empty, and moves list must have at least 4 entries.");
    }

    public string PickAName()
    {
        // pick a name
        if (UsedNames.Count >= Names.Count)
            UsedNames.Clear();
        string name;
        do
        {
            name = Names[Random.Next(Names.Count)];
        } while (UsedNames.Contains(name));
        UsedNames.Add(name);
        return name;
    }

    public List<string> PickTheMoves()
    {
        // pick the moves
        List<string> wrestlerMoves = new List<string>();
        List<int> usedIndices = new List<int>();
        while (wrestlerMoves.Count < 4)
        {
            int index = Random.Next(Moves.Count);
            if (!usedIndices.Contains(index))
            {
                usedIndices.Add(index);
                wrestlerMoves.Add(Moves[index]);
            }
        }

        return wrestlerMoves;
    }

    public string PickACatchPhrase()
    {
        // pick a catchphrase
        int catchphraseIndex = Random.Next(Catchphrases.Count);
        string catchphrase = Catchphrases[catchphraseIndex];
        return catchphrase;
    }

    public BreedInfo PickTheBreed()
    {
        // pick the breed
        int breedIndex = Random.Next(Breeds.Count);
        BreedInfo breedInfo = Breeds[breedIndex];
        return breedInfo;
    }

    public Wrestler GenerateWrestler()
    {

        return new Wrestler(PickAName(), PickACatchPhrase(), PickTheMoves(), PickTheBreed());
    }
}