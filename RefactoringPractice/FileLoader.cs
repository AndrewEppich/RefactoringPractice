namespace RefactoringPractice;

public class FileLoader
{
    //  public List<string> Names;
    // public List<string> Catchphrases;
    // public List<string> Moves;
    public List<BreedInfo> Breeds;
    
    public string BreedsFilename = "breeds.txt";

    public bool IfFileExists(string Filename)
    {
        return File.Exists(Filename);
    }
    

 

    public List<BreedInfo> LoadBreedInfo()
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

        return Breeds;
    }

    public List<string> LoadFile(string filename, List<string> listFromFile)
    {
        if (!IfFileExists(filename))
            throw new FileNotFoundException($"File not found: {filename}");
        listFromFile = new List<string>();
        foreach (string line in File.ReadLines(filename))
        {
            string trimmed = line.Trim();
            if (trimmed.Length > 0) 
            {
                listFromFile.Add(trimmed);
            }
        }

        return listFromFile;
    }
}