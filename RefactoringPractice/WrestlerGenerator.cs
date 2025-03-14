namespace RefactoringPractice;

using System;
using System.Collections.Generic;
using System.IO;

public class WrestlerGenerator
{
    public List<string> Names;
    public List<string> Catchphrases;
    public List<string> Moves;
    public List<BreedInfo> Breeds;
    public List<string> UsedNames = new List<string>();
    public Random Random = new Random();
    
    public string NamesFilename = "names.txt";
    public string CatchphrasesFilename = "phrases.txt";
    public string MovesFilename = "moves.txt";
    public string BreedsFilename = "breeds.txt";

    public bool IfFileExists(string Filename)
    {
        return File.Exists(Filename);
    }
    

    public void LoadNames()
    {
        // load the names
        if (!IfFileExists(NamesFilename))
            throw new FileNotFoundException($"File not found: {NamesFilename}");
        Names = new List<string>();
        foreach (string line in File.ReadLines(NamesFilename))
        {
            string trimmed = line.Trim();
            if (trimmed.Length > 0) 
            {
                Names.Add(trimmed);
            }
        }    }

    public void LoadCatchphrases()
    {
        // load the catchphrases
        if (!IfFileExists(CatchphrasesFilename))
            throw new FileNotFoundException($"File not found: {CatchphrasesFilename}");
        Catchphrases = new List<string>();
        foreach (string line in File.ReadLines(CatchphrasesFilename))
        {
            string trimmed = line.Trim();
            if (trimmed.Length > 0) 
            {
                Catchphrases.Add(trimmed);
            }
        }
    }

    public void LoadMoves()
    {
        // load the moves
        if (!IfFileExists(MovesFilename))
            throw new FileNotFoundException($"File not found: {MovesFilename}");
        Moves = new List<string>();
        foreach (string line in File.ReadLines(MovesFilename))
        {
            string trimmed = line.Trim();
            if (trimmed.Length > 0) 
            {
                Moves.Add(trimmed);
            }
        }
    }

    public void LoadBreedInfo()
    {
        // load the breed information
        if (!IfFileExists(BreedsFilename))
            throw new FileNotFoundException($"File not found: {BreedsFilename}");
        Breeds = new List<BreedInfo>();
        foreach (string line in File.ReadLines(BreedsFilename))
        {
            string[] parts = line.Split(';');
            if (parts.Length == 3)
            {
                Breeds.Add(new BreedInfo(parts[0].Trim(), parts[1].Trim(), parts[2].Trim()));
            }
        }
    }
    public WrestlerGenerator()
    {
        LoadNames();
        LoadCatchphrases();
        LoadMoves();
        LoadBreedInfo();
        
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