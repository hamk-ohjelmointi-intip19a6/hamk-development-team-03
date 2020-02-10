using System;
using Newtonsoft.Json;


namespace ZombieLottoV2
{
    /*TODO:
   *
   * ID.(STATUS). TASK
    1.() Ask user how many line number he/she want to add
        a) Note! There is no limit how many number line user want to add
    2.(In progress) Zombielotto program guess 5 numbers between 1-25 when money is 10 dollar.
    3.() Program save 5 numbers to JSON file as won number line

   *
   *
   *
   *
   * */

    class StartUserInterface
    {
        // startmenu: Paavo Latvaniemi 2020
        // program doesn't go to the main menu if successfulSignIn is false
        public static bool successfulSignIn = false;
        public static void Startmenu()
        {
            while (successfulSignIn == false)
            {
                Console.WriteLine("[1]Sign in\nor\n[2]Sign up");
                var choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Username: ");
                    string signInUsername = Console.ReadLine();

                    Console.WriteLine("Password: ");
                    string signInPassword = Console.ReadLine();

                    UserProfile.SignIn(signInUsername, signInPassword);

                }
                else if (choice == "2")
                {
                    Console.WriteLine("Username: ");
                    string signUpUsername = Console.ReadLine();

                    Console.WriteLine("Password: ");
                    string signUpPassword = Console.ReadLine();

                    Console.WriteLine("Age: ");
                    int signUpAge = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Phone: ");
                    string signUpPhone = Console.ReadLine();

                    Console.WriteLine("Email: ");
                    string signUpEmail = Console.ReadLine();

                    UserProfile.SignUp(signUpUsername, signUpPassword, signUpAge, signUpPhone, signUpEmail);
                }
            }
        }
    }

    public class UserInterface
    {
        public static void UserChooseOption()
        {
            // userInterface: Rohullah Karimi 2020
            int option;
            Console.WriteLine("Choose your option\n [1] Completed line \n [2] Choose your numbers");
            option = Int32.Parse(Console.ReadLine());
            if (option == 1)
            {
                UserChooseNumbers.ProgramGuessNumbersForUser();
            }
            else if (option == 2)
            {
                UserChooseNumbers.AskUserForFiveNumbers();
            }
            else
            {
                Console.WriteLine("Choose 1 or 2 to continue");
            }
        }
    }

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


    public class LotteryDay
    {
        public static void LotteryNumber()
        {
            zombieLottoLotteryDay receivedMoney = new zombieLottoLotteryDay();

            double getMoneyValue = zombieLottoLotteryDay.ReceivedMoney();
            Console.WriteLine("Collected money is: " + getMoneyValue);
        }
    }

    public class zombieLottoLotteryDay
    {
        static double receivedMoney { get; set; }
      
        public static double ReceivedMoney()
        {
            // this is test value for receivedMoney 
            receivedMoney = 10.00;
            return receivedMoney;
        }
    }
}




