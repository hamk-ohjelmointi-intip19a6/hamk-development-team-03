using System;
using Newtonsoft.Json;


namespace ZombieLottoV2
{
    /*TODO:
   *
    3.(In progress) Program save 5 numbers to JSON file as won number line
    4.(In progress) Program save 5 numbers to JSON file as user number line base on user Id
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
                UserChooseNumbers.AddToJson();
            }
            else if (option == 2)
            {
                UserChooseNumbers.AskUserForFiveNumbers();
                UserChooseNumbers.AddToJson();
            }
            else
            {
                Console.WriteLine("Choose 1 or 2 to continue");
            }
        }
    }
}




