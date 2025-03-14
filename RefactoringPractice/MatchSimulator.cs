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

    public void RunMatchSeries()
    {
        Console.WriteLine("========================================================================");
        Console.WriteLine("Welcome to the Dog Wrestling League Championship!");
        Console.WriteLine("-------------------------------------------------");
        Wrestler first = WrestlerGenerator.GenerateWrestler();
        Wrestler second = WrestlerGenerator.GenerateWrestler();


        Console.WriteLine($"==> Best of Three: {first.Name} vs. {second.Name} <==");
        Console.WriteLine($"Introducing {first.Name} ({first.Breed} - {first.WrestlerName})");
        Console.WriteLine($"    {first.Description}");
        Console.WriteLine($"Introducing {second.Name} ({second.Breed} - {second.WrestlerName})");
        Console.WriteLine($"    {second.Description}");

        int winsPlayer1 = 0;
        int winsPlayer2 = 0;

        for (int matchNumber = 1; matchNumber <= 3; matchNumber++)
        {
            Console.WriteLine($"\n--- Match {matchNumber} ---");
            Console.WriteLine("Press Enter to begin the match...");
            Console.ReadLine();
            
            int healthPlayer1 = 100;
            int healthPlayer2 = 100;

            while (healthPlayer1 > 0 && healthPlayer2 > 0)
            {
                int damagePlayer1 = Random.Next(10, 21);
                healthPlayer2 -= damagePlayer1;

                if (healthPlayer2 <= 0) break;       

                int damagePlayer2 = Random.Next(10, 21);
                healthPlayer1 -= damagePlayer2;
            }

            Wrestler matchWinner;
            if (healthPlayer1 > 0)
            {
                matchWinner = first;
            }
            else
            {
                matchWinner = second;
            }
            Console.WriteLine($"Winner of Match {matchNumber}: {matchWinner.Name} ({matchWinner.Breed})");
            Console.WriteLine($"Finishing move: {matchWinner.Moves[Random.Next(matchWinner.Moves.Count)]}");

            if (matchWinner == first)
            {
                winsPlayer1++;
            }
            else
            {
                winsPlayer2++;
            }
            
            if (winsPlayer1 == 2 || winsPlayer2 == 2)
            {
                break;
            }
        }
        
        Wrestler gameWinner;
        if (winsPlayer1 > winsPlayer2)
        {
            gameWinner = first;
        }
        else
        {
            gameWinner = second;
        }
        
        int synonymIndex = Random.Next(shoutSynonyms.Count);
        string randomShoutSynonym = shoutSynonyms[synonymIndex];
        Console.WriteLine($"\n{gameWinner.Name} ({gameWinner.Breed}) wins, {randomShoutSynonym}: \"{gameWinner.Catchphrase}\"");
    }
}
