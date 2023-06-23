using RockPaperScissors.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Title = "Rock paper scissors";
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetWindowPosition(32, 32);
        
        // Program loop
        while (true)
        {
            TournamentModel tournament = new TournamentModel();
            tournament.startFight();
        }
    }
}