using System;
namespace ZombieLottoV2
{
    public class UserChooseNumbers
    {
        public static void ProgramGuessNumbersForUser()
        {
            int[] lineNumber = new int[5];
            Random randomNumbers = new Random();

            for (int round = 0; round < 5; round++)
            {
                int num = randomNumbers.Next(1, 25);
                lineNumber[round] = num;
            }
            Console.WriteLine("Your number line is: " + "{0}", string.Join(", ", lineNumber));
            Console.ReadLine();
        }

        public static void AskUserForFiveNumbers()
        {
            int[] lineNumber = new int[5];

            for (int round = 0; round < 5; round++)
            {
                int roundStartsFromOne = round + 1;
                Console.WriteLine("Choose your number " + roundStartsFromOne + ":");
                string readLine = Console.ReadLine();
                int num = Int32.Parse(readLine);
                if (int.TryParse(readLine, out int n) && num < 1 | num > 25)
                {
                    Console.WriteLine("Wrong number. Choose between 1-25");
                }
                else
                {
                    lineNumber[round] = num;
                }
            }
            Console.WriteLine("Your number line is: " + "{0}", string.Join(", ", lineNumber));
            Console.ReadLine();
        }
    }
}
