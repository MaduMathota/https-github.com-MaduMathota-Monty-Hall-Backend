namespace MontyHallBackend
{
    public class MontyHallPuzzle
    {
        private readonly int simulations;
        private readonly bool changeDoor;
        private int totalSwitchDoorWins = 0;
        private int totalStayDoorWins = 0;
        private readonly Random random = new Random();
        private string goatImage = "goat";
        private string carImage = "car";



        public MontyHallPuzzle(int simulations, bool changeDoor)
        {
            this.simulations = simulations;
            this.changeDoor = changeDoor;
        }

        public void RunSimulations()
        {
            for (int i = 0; i < simulations; i++)
            {
                string[] doors = { goatImage, goatImage, goatImage };
                int carIndex = random.Next(0, 3);
                doors[carIndex] = carImage;

                int initialChoice = random.Next(0, 3);
                int revealed;

                do
                {
                    revealed = random.Next(0, 3);
                } while (revealed == initialChoice || doors[revealed] == carImage);

                if (changeDoor)
                {
                    initialChoice = 3 - initialChoice - revealed;
                }

                UpdateWinCounts(doors, initialChoice);
            }
        }

        private void UpdateWinCounts(string[] doors, int initialChoice)
        {
            if (doors[initialChoice] == carImage)
            {
                if (changeDoor)
                {
                    totalSwitchDoorWins++;
                }
                else
                {
                    totalStayDoorWins++;
                }
            }
        }

        public double GetSwitchWinRate()
        {
            return CalculateWinRate(totalSwitchDoorWins);
        }

        public double GetStayWinRate()
        {
            return CalculateWinRate(totalStayDoorWins);
        }

        private double CalculateWinRate(int totalWins)
        {
            if (simulations == 0)
            {
                return 0;
            }
            return (double)totalWins / simulations * 100;
        }
    }
}
