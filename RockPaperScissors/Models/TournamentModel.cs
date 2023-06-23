using System.Runtime.CompilerServices;

namespace RockPaperScissors.Models
{
    internal class TournamentModel : DialogueController
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
            ClearAndWrite("What's your name kid?");
            player.name = Console.ReadLine();
            ClearAndWrite($"Okay {player.name}, you choose the win condition.\nHow many round wins are necessary for winning a match?");
            int winCondition;
            while (!Int32.TryParse(Console.ReadLine(), out winCondition))
            {
                WriteLine("Please input a number of wins necessary for winning a match.");
            }

            int roundsWon = 0, roundsLost = 0;
            while (roundsWon < 3 && roundsLost < 1) {
                if (match.StartFight(winCondition))
                {
                    roundsWon++;
                } else
                {
                    roundsLost++;
                }
            }
            if (roundsLost > 0)
            {
                WriteLine("You lost");
            } else 
            {
                WriteLine("You Won");
            }
            WaitForPlayerContinue();
        }

    }
}
