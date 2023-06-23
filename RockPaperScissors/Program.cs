using RockPaperScissors.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Title = "Rock paper scissors";
        
        // Program loop
        while (true)
        {
            TournamentModel tournament = new TournamentModel();
            tournament.startFight();
        }
    }
}