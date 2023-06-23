namespace RockPaperScissors.Models
{
    internal class MatchModel
    {
        private ComputerAIModel computer;
        private PlayerModel player;
        private int winCount;
        
        public MatchModel(ComputerAIModel comp, PlayerModel user)
        {
            computer = comp;
            player = user;
        }

        private static string ComputeOutcome(string player, string computer)
        {
            if (player == computer)
            {
                return "tie";
            }
            else if (player == "rock" && computer == "paper")
            {
                return "loss";
            }
            else if (player == "rock" && computer == "scissors")
            {
                return "win";
            }
            else if (player == "paper" && computer == "rock")
            {
                return "win";
            }
            else if (player == "paper" && computer == "scissors")
            {
                return "loss";
            }
            else if (player == "scissors" && computer == "paper")
            {
                return "win";
            }
            // (player == "scissors" && computer == "rock")
            else
            {
                return "loss";
            }
        }

        private void Quit()
        {
            Environment.Exit(0);
        }

        public void startFight(int winCondition)
        {
            int playerWins = 0, playerLoses = 0, ties = 0;
            winCount = winCondition;
            string computerInput;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Wins: {playerWins}, Loses: {playerLoses}, Ties: {ties}");
                // Displays current computer bias and aggression
                //Console.WriteLine($"Computer aggression: +{computer.aggression}, Computer bias: Rock: { computer.bias[0]}, Paper: { computer.bias[1]}, Scissors: { computer.bias[2]}");
                Console.WriteLine($"Opponent: {computer.name}");
                Console.WriteLine("\nChoose rock, paper, scissors, quit, or restart");
                Console.Write("Choice: ");
                string playerInput = Console.ReadLine();
                if (playerInput == null)
                {
                    Console.Clear();
                    Console.WriteLine("Please make a valid choice.");
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                }
                else if (playerInput == "quit")
                {
                    Quit();
                }
                else if (playerInput == "restart")
                {
                    break;
                }
                else if (playerInput == "rock" || playerInput == "paper" || playerInput == "scissors")
                {
                    Console.Clear();
                    computerInput = computer.GenerateChoice();
                    Console.WriteLine($"The computer chose: {computerInput}.");
                    switch (ComputeOutcome(playerInput, computerInput))
                    {
                        case "win":
                            playerWins++;
                            Console.WriteLine("You won!");
                            break;
                        case "loss":
                            playerLoses++;
                            Console.WriteLine("You lost.");
                            break;
                        case "tie":
                            ties++;
                            Console.WriteLine("It's a tie.");
                            break;
                    };
                    if (playerWins == winCount)
                    {
                        Console.WriteLine("You won the match");
                    } else if (playerLoses == winCount) {
                        Console.WriteLine("You lost the match");
                    } else
                    {
                        computer.AdaptBias(playerInput);
                    }
                    Console.Write("\nType any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{playerInput} is not a valid choice.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
