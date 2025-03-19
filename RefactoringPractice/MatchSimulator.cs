namespace RefactoringPractice;

using System;

public class MatchSimulator
{
    public WrestlerGenerator WrestlerGenerator;
    public Random Random = new Random();
    public int winsWrestler1 { get; set; } = 0;
    public int winsWrestler2 { get; set; } = 0;
    public int healthWrestler1 { get; set; } = 100;
    public int healthWrestler2 { get; set; } = 100;
    public List<string> shoutSynonyms = new List<string>()
    {
        "shouting",
        "yelling",
        "screaming",
        "bellowing",
        "roaring",
        "exclaiming"
    };

    public MatchSimulator()
    {
        WrestlerGenerator = new WrestlerGenerator();
    }

    public void writeIntroToConsole(Wrestler first, Wrestler second){
        Console.WriteLine("========================================================================");
        Console.WriteLine("Welcome to the Dog Wrestling League Championship!");
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine($"==> Best of Three: {first.Name} vs. {second.Name} <==");
        Console.WriteLine($"Introducing {first.Name} ({first.Breed} - {first.WrestlerName})");
        Console.WriteLine($"    {first.Description}");
        Console.WriteLine($"Introducing {second.Name} ({second.Breed} - {second.WrestlerName})");
        Console.WriteLine($"    {second.Description}");
    }

    public void runSingleWrestlerMatch(Wrestler wrestler1, Wrestler wrestler2){
        healthWrestler1 = 100;
        healthWrestler2 = 100;

        while (healthWrestler1 > 0 && healthWrestler2 > 0){
                int damageFromPlayer1 = Random.Next(10, 21);
                healthWrestler2 -= damageFromPlayer1;

                if (healthWrestler2 <= 0) break;       

                int damageFromPlayer2 = Random.Next(10, 21);
                healthWrestler1 -= damageFromPlayer2;
        }
        Wrestler matchWinner;
        if (healthWrestler1 > 0){
            matchWinner = wrestler1;
        }
            else{
            matchWinner = wrestler2;
        }
        Console.WriteLine($"Winner of Match {matchNumber}: {matchWinner.Name} ({matchWinner.Breed})");
        Console.WriteLine($"Finishing move: {matchWinner.Moves[Random.Next(matchWinner.Moves.Count)]}");
        if (matchWinner == wrestler1){
            winsWrestler1++;
        }
        else{
            winsWrestler2++;
        }     
        if (winsWrestler1 == 2 || winsWrestler2 == 2){
            break;
        }
    }

    public Wrestler determineWinner(Wrestler wrestler1, Wrestler wrestler2){
        Wrestler gameWinner;
        if (winsWrestler1 > winsWrestler2)
        {
            gameWinner = wrestler1;
        }
        else
        {
            gameWinner = wrestler2;
        }
        return gameWinner;
    }


    public void RunMatchSeries()
    {
        Wrestler wrestler1 = WrestlerGenerator.GenerateWrestler();
        Wrestler wrestler2 = WrestlerGenerator.GenerateWrestler();
        writeIntroToConsole(wrestler1, wrestler2);


        for (int matchNumber = 1; matchNumber <= 3; matchNumber++)
        {
            Console.WriteLine($"\n--- Match {matchNumber} ---");
            Console.WriteLine("Press Enter to begin the match...");
            Console.ReadLine();
            
            runSingleWrestlerMatch(wrestler1, wrestler2);
        }
        
        Wrestler matchWinner = determineWinner(wrestler1, wrestler2);
        
        int synonymIndex = Random.Next(shoutSynonyms.Count);
        string randomShoutSynonym = shoutSynonyms[synonymIndex];
        Console.WriteLine($"\n{matchWinner.Name} ({matchWinner.Breed}) wins, {randomShoutSynonym}: \"{matchWinner.Catchphrase}\"");
    }
}
    