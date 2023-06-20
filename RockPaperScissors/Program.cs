internal class Program
{

    public static void Quit()
    {
        Environment.Exit(0);
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

    public static int[] AdaptComputerBias(int[] oldBias, string playerLastUsed)
    {
        int[] newBias = oldBias;
        Random rng = new Random();
        rng.Next(2);

        switch (playerLastUsed)
        {
            case "rock":
                newBias[1]++;
                switch (rng.Next(2))
                {
                    case 0:
                        newBias[0]--;
                        break;
                    case 1:
                        newBias[2]--;
                        break;
                }
                return newBias;
            case "paper":
                newBias[2]++;
                switch (rng.Next(2))
                {
                    case 0:
                        newBias[0]--;
                        break;
                    case 1:
                        newBias[1]--;
                        break;
                }
                return newBias;
            default:
                newBias[0]++;
                switch (rng.Next(2))
                {
                    case 0:
                        newBias[1]--;
                        break;
                    case 1:
                        newBias[2]--;
                        break;
                }
                return newBias;
        }
        
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

                // Displays the computer bias
                Console.WriteLine($"Computer bias: Rock: {compBias[0]}, Paper: {compBias[1]}, Scissors: {compBias[2]}");

                Console.WriteLine("\nChoose rock, paper, scissors, quit, or restart");
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
                    compBias = AdaptComputerBias(compBias, playerInput);
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