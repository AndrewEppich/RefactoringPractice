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

    public WrestlerGenerator()
    {
        // load the names
        if (!File.Exists(NamesFilename))
            throw new FileNotFoundException($"File not found: {NamesFilename}");
        Names = new List<string>();
        foreach (string line in File.ReadLines(NamesFilename))
        {
            string trimmed = line.Trim();
            if (trimmed.Length > 0) 
            {
                Names.Add(trimmed);
            }
        }
        
        // load the catchphrases
        if (!File.Exists(CatchphrasesFilename))
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
        
        // load the moves
        if (!File.Exists(MovesFilename))
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
        
        // load the breed information
        if (!File.Exists(BreedsFilename))
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

        if (Names.Count == 0 || Catchphrases.Count == 0 || Moves.Count < 4 || Breeds.Count == 0)
            throw new InvalidOperationException("Files cannot be empty, and moves list must have at least 4 entries.");
    }

    public Wrestler GenerateWrestler()
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
        
        // pick a catchphrase
        int catchphraseIndex = Random.Next(Catchphrases.Count);
        string catchphrase = Catchphrases[catchphraseIndex];
        
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
        
        // pick the breed
        int breedIndex = Random.Next(Breeds.Count);
        BreedInfo breedInfo = Breeds[breedIndex];

        return new Wrestler(name, catchphrase, wrestlerMoves, breedInfo);
    }
}


