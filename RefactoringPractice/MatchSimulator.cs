namespace RefactoringPractice;

using System;

public class MatchSimulator
{
    public WrestlerGenerator WrestlerGenerator;
    public Random Random = new Random();
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

    public void RunMatchSeries()
    {
        Wrestler wrestler1 = WrestlerGenerator.GenerateWrestler();
        Wrestler wrestler2 = WrestlerGenerator.GenerateWrestler();
        writeIntroToConsole(wrestler1, wrestler2);


        int winsWrestler1 = 0;
        int winsWrestler2 = 0;

        for (int matchNumber = 1; matchNumber <= 3; matchNumber++)
        {
            runSingleMatch();
           
        }
        
        Wrestler gameWinner;
        if (winsWrestler1 > winsWrestler2)
        {
            gameWinner = wrestler1;
        }
        else
        {
            gameWinner = wrestler2;
        }
        
        int synonymIndex = Random.Next(shoutSynonyms.Count);
        string randomShoutSynonym = shoutSynonyms[synonymIndex];
        Console.WriteLine($"\n{gameWinner.Name} ({gameWinner.Breed}) wins, {randomShoutSynonym}: \"{gameWinner.Catchphrase}\"");
    }

    public void runSingleMatch()
    {
        Console.WriteLine($"\n--- Match {matchNumber} ---");
        Console.WriteLine("Press Enter to begin the match...");
        Console.ReadLine();
            
        int healthWrestler1 = 100;
        int healthWrestler2 = 100;

        while (healthWrestler1 > 0 && healthWrestler2 > 0)
        {
            int damageFromPlayer1 = Random.Next(10, 21);
            healthWrestler2 -= damageFromPlayer1;

            if (healthWrestler2 <= 0) break;       

            int damageFromPlayer2 = Random.Next(10, 21);
            healthWrestler1 -= damageFromPlayer2;
        }

        Wrestler matchWinner;
        if (healthWrestler1 > 0)
        {
            matchWinner = wrestler1;
        }
        else
        {
            matchWinner = wrestler2;
        }
        Console.WriteLine($"Winner of Match {matchNumber}: {matchWinner.Name} ({matchWinner.Breed})");
        Console.WriteLine($"Finishing move: {matchWinner.Moves[Random.Next(matchWinner.Moves.Count)]}");

        if (matchWinner == wrestler1)
        {
            winsWrestler1++;
        }
        else
        {
            winsWrestler2++;
        }
            
        if (winsWrestler1 == 2 || winsWrestler2 == 2)
        {
            break;
        }
    }

    public void runFight()
    {
        
    }
}
