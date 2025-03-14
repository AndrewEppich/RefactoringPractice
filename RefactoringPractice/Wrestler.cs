namespace RefactoringPractice;

public class Wrestler
{
    public string Name;
    public string Catchphrase;
    public List<string> Moves;
    public string Breed;
    public string WrestlerName;
    public string Description;

    public Wrestler(string name, string catchphrase, 
        List<string> moves, BreedInfo breedInfo)
    {
        Name = name;
        Catchphrase = catchphrase;
        Moves = moves;
        Breed = breedInfo.Breed;
        WrestlerName = breedInfo.WrestlerName;
        Description = breedInfo.Description;
    }
}
