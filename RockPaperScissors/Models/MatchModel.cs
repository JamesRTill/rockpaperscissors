namespace RockPaperScissors.Models
{
    internal class MatchModel : DialogueController
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

        public bool StartFight(int winCondition)
        {
            int playerWins = 0, playerLoses = 0, ties = 0;
            winCount = winCondition;
            string computerInput;

            while (true)
            {
                ClearAndWrite($"Wins: {playerWins}, Loses: {playerLoses}, Ties: {ties}");
                // Displays current computer bias and aggression
                //WriteLine($"Computer aggression: +{computer.aggression}, Computer bias: Rock: { computer.bias[0]}, Paper: { computer.bias[1]}, Scissors: { computer.bias[2]}");
                WriteLine($"Opponent: {computer.name}");
                WriteLine("\nChoose rock, paper, scissors, quit, or restart");
                Write("Choice: ");
                string playerInput = Console.ReadLine();
                if (playerInput == null)
                {
                    ClearAndWrite("Please make a valid choice.");
                    WaitForPlayerContinue();
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
                    ClearConsole();
                    computerInput = computer.GenerateChoice();
                    WriteLine($"The computer chose: {computerInput}.");
                    switch (ComputeOutcome(playerInput, computerInput))
                    {
                        case "win":
                            playerWins++;
                            WriteLine("You won!");
                            break;
                        case "loss":
                            playerLoses++;
                            WriteLine("You lost.");
                            break;
                        case "tie":
                            ties++;
                            WriteLine("It's a tie.");
                            break;
                    };
                    if (playerWins == winCount)
                    {
                        WriteLine("You won the match!");
                        WaitForPlayerContinue();
                        ClearConsole();
                        return true;
                    } else if (playerLoses == winCount) {
                        WriteLine("You lost the match...");
                        WaitForPlayerContinue();
                        ClearConsole();
                        return false;
                    } else
                    {
                        computer.AdaptBias(playerInput);
                    }
                    WaitForPlayerContinue();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{playerInput} is not a valid choice.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            return false;
        }
    }
}
