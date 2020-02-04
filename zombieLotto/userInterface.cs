﻿using System;
namespace ZombieLotto
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
        public static void startmenu()
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
                    string signUpAge = Console.ReadLine();

                    Console.WriteLine("Phone: ");
                    string signUpPhone = Console.ReadLine();

                    Console.WriteLine("Email: ");
                    string signUpEmail = Console.ReadLine();

                    UserProfile.SignUp(signUpUsername, signUpPassword, signUpAge, signUpPhone, signUpEmail);
                }
            }
        }
    }

public class userInterface
    {
        public static void UserChooseOption()
        {
            // userInterface: Rohullah Karimi 2020
            int option;
            Console.WriteLine("Choose your option\n 1. Completed line \n 2. Choose your numbers");
            option = Int32.Parse(Console.ReadLine());
            if (option == 1)
            {
                userChooseNumbers.ProgramGuessNumbersForUser();
            }
            else if (option == 2)
            {
                userChooseNumbers.AskUserForFiveNumbers();
            }
            else
            {
                Console.WriteLine("Choose 1 or 2 to continue");
            }
        }
    }



public class userChooseNumbers
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

           // double getMoneyValue = zombieLottoLotteryDay.CheckForReceivedMoney();
            //Console.WriteLine("tervehdys arvo: " + haeTervehdysArvot);
        }
    }

    public class zombieLottoLotteryDay
    {
        double receivedMoney { get; set; }

      
        public static void ReceivedMoney()
        {
            // this is test value for receivedMoney 
            double receivedMoney = 10.00;
        }

       // public double CheckForReceivedMoney()
     //   {
           // return ReceivedMoney;
     //   }
    }
}

/*
 *
 *
 *    class Program
    {
      
        public static void Main(string[] args)
        {
            Tervehtijä tervehtija = new Tervehtijä();

            // aseta metoodit
            tervehtija.AsetaTervehdys("");
            tervehtija.Tervehdi("");

            var haeTervehdysArvot = tervehtija.HaeTervehdys();
            Console.WriteLine("tervehdys arvo: " + haeTervehdysArvot);
        }
    }
    public class Tervehtijä
    {
        //string tervehdys, itseTervehdys;

        string tervehdys { get; set; }
        string OmaTervehdys { get; set; }

        public void AsetaTervehdys(string uusiTervehdys)
        {
            tervehdys = "Moi";
            var uusitervehdys = "Moikka";
        }
        public void Tervehdi(string omaTervehdys)
        {
            OmaTervehdys = "Moro";
        }
        public string HaeTervehdys()
        {
            return tervehdys;
        }
    }
 *
 * */



