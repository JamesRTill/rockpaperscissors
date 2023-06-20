internal class Program
{

    public static void Quit()
    {
        
    }

    public static int[] GenerateRandomBias()
    {
        int[] outcome = { 0, 0, 0 };
        Random rng = new Random();
        for (int i = 0; i < 10; i++)
        {
            switch (rng.Next(3))
            {
                case 0:
                    outcome[0]++;
                    break;
                case 1:
                    outcome[1]++;
                    break;
                default:
                    outcome[2]++;
                    break;
            }
        }
        return outcome;
    }

    public static string GenerateComputerChoice(int[] bias)
    {
        Random rng = new Random();

        if (rng.Next(10) < bias[0])
        {
            return "rock";
        }
        else if (rng.Next(10) < bias[0] + bias[1])
        {
            return "paper";
        }
        else
        {
            return "scissors";
        }
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
        string compInput;
        int playerWins, playerLoses, ties;
        
        // Program loop
        while (true)
        {
            
            playerWins = 0; playerLoses = 0; ties = 0;
            int[] compBias = GenerateRandomBias();

            // Gameplay loop
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Wins: {playerWins}, Loses: {playerLoses}, Ties: {ties}");
                Console.WriteLine("\nChoose rock, paper, scissors, or restart");
                Console.Write("Choice: ");
                string playerInput = Console.ReadLine();
                if (playerInput == null)
                {
                    Console.Clear();
                    Console.WriteLine("Please make a valid choice.");
                    Console.WriteLine("Press any key to continue");
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
                    compInput = GenerateComputerChoice(compBias);
                    Console.WriteLine($"The computer chose: {compInput}.");
                    switch (ComputeOutcome(playerInput, compInput))
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
                    Console.Write("\nType any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{playerInput} is not a valid choice.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

            }
            
        }
    }
}