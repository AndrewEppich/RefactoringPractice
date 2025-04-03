namespace RefactoringPractice;
using System;
public class Match
{
    private Random Random = new Random();
    
    public Match()
    {
        
    }
    
    public Wrestler determineMatchWinner(Wrestler wrestler1, Wrestler wrestler2){
        int healthWrestler1 = 100;
        int healthWrestler2 = 100;
    
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
        return matchWinner;
      
    }

    public void displayMatchWinner(Wrestler matchWinner, int matchNumber)
    {
        Console.WriteLine($"Winner of Match {matchNumber}: {matchWinner.Name} ({matchWinner.Breed})");
        Console.WriteLine($"Finishing move: {matchWinner.Moves[Random.Next(matchWinner.Moves.Count)]}");
    }

}