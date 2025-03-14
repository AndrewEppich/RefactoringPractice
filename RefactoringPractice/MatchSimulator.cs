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

        int num1 = 0;
        int num2 = 0;

        for (int n = 1; n <= 3; n++)
        {
            Console.WriteLine($"\n--- Match {n} ---");
            Console.WriteLine("Press Enter to begin the match...");
            Console.ReadLine();
            
            int val1 = 100;
            int val2 = 100;

            while (val1 > 0 && val2 > 0)
            {
                int n1 = Random.Next(10, 21);
                val2 -= n1;

                if (val2 <= 0) break;       

                int n2 = Random.Next(10, 21);
                val1 -= n2;
            }

            Wrestler third;
            if (val1 > 0)
            {
                third = first;
            }
            else
            {
                third = second;
            }
            Console.WriteLine($"Winner of Match {n}: {third.Name} ({third.Breed})");
            Console.WriteLine($"Finishing move: {third.Moves[Random.Next(third.Moves.Count)]}");

            if (third == first)
            {
                num1++;
            }
            else
            {
                num2++;
            }
            
            if (num1 == 2 || num2 == 2)
            {
                break;
            }
        }
        
        Wrestler fourth;
        if (num1 > num2)
        {
            fourth = first;
        }
        else
        {
            fourth = second;
        }
        
        int synonymIndex = Random.Next(shoutSynonyms.Count);
        string randomShoutSynonym = shoutSynonyms[synonymIndex];
        Console.WriteLine($"\n{fourth.Name} ({fourth.Breed}) wins, {randomShoutSynonym}: \"{fourth.Catchphrase}\"");
    }
}
