namespace RockPaperScissors.Models
{
    internal class TournamentModel
    {
        private ComputerAIModel computer;
        private PlayerModel player;
        private MatchModel match;

        public TournamentModel()
        {
            computer = new ComputerAIModel();
            player = new PlayerModel();
            match = new MatchModel(computer, player);
        }

        public void startFight()
        {
            Console.Clear();
            Console.WriteLine("What's your name kid?");
            player.name = Console.ReadLine();
            Console.WriteLine($"Okay {player.name}, how many is the win condition?");
            int winCondition;
            while (!Int32.TryParse(Console.ReadLine(), out winCondition))
            {
                Console.WriteLine("Please input a number of wins necessary for winning a match.");
            }
            
            match.startFight(winCondition);
        }

    }
}
