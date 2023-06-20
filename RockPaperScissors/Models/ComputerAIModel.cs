namespace RockPaperScissors.Models
{
    public class ComputerAIModel
    {
        public string name;
        public int aggression;
        public int[] bias;

        private string GenerateName()
        {
            string[] nameList =
            {
                "James", "John", "Jill", "Kate", "Brad", "Todd", "Ted", "Brandy", "Alex", "Mom", "Mary", "Zero", "Kid"
            };
            Random rng = new Random();
            return nameList[rng.Next(nameList.Length)];
        }
        private int GenerateAggression()
        {
            Random rng = new Random();
            return rng.Next(3) + 1;
        }
        private int[] GenerateBias()
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
        public void AdaptBias(string playerLastUsed)
        {
            int[] newBias = bias;
            Random rng = new Random();
            rng.Next(2);

            switch (playerLastUsed)
            {
                case "rock":
                    newBias[1] += aggression;
                    switch (rng.Next(2))
                    {
                        case 0:
                            newBias[0] -= aggression;
                            break;
                        case 1:
                            newBias[2] -= aggression;
                            break;
                    }
                    break;
                case "paper":
                    newBias[2] += aggression;
                    switch (rng.Next(2))
                    {
                        case 0:
                            newBias[0] -= aggression;
                            break;
                        case 1:
                            newBias[1] -= aggression;
                            break;
                    }
                    break;
                default:
                    newBias[0] += aggression;
                    switch (rng.Next(2))
                    {
                        case 0:
                            newBias[1] -= aggression;
                            break;
                        case 1:
                            newBias[2] -= aggression;
                            break;
                    }
                    break;
            }
            bias = newBias;
        }
        public string GenerateChoice()
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

        // Constructor
        public ComputerAIModel()
        {
            name = GenerateName();
            aggression = GenerateAggression();
            bias = GenerateBias();
        }
    }
}
