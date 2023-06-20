using RockPaperScissors.Models;

internal class Program
{

    public static void Quit()
    {
        Environment.Exit(0);
    }
    public static string ComputeOutcome(string player, string computer)
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


    private static void Main(string[] args)
    {
        Console.Title = "Rock paper scissors";
        string computerInput;
        int playerWins, playerLoses, ties;
        
        // Program loop
        while (true)
        {
            
            playerWins = 0; playerLoses = 0; ties = 0;
            ComputerAIModel computer = new ComputerAIModel();

            // Gameplay loop
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
                            Console.Write("You won!");
                            break;
                        case "loss":
                            playerLoses++;
                            Console.Write("You lost.");
                            break;
                        case "tie":
                            ties++;
                            Console.Write("It's a tie.");
                            break;
                    };
                    computer.AdaptBias(playerInput);
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