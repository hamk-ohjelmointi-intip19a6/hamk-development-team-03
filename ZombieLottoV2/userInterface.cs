using System;
using System.Collections.Generic;
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

    public class UserInterface
    {
        // startmenu: Paavo Latvaniemi 2020
        // program doesn't go to the main menu if successfulSignIn is false
        public static bool successfulSignIn = false;
        public static void Startmenu()
        {
            while (successfulSignIn == false)
            {
                Console.WriteLine("Start menu");
                Console.WriteLine("-------------------------");
                Console.WriteLine("[1]Sign in\n[2]Sign up");
                var choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Username: ");
                    string signInUsername = Console.ReadLine();
                    Console.Clear();
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
                Console.Clear();
            }
        }

        public static void MainMenu()
        {
            Console.WriteLine("Main menu");
            Console.WriteLine("-------------------------");
            Console.WriteLine(
                "[1] - My Profile\n" +
                "[2] - History\n" +
                "[3] - Buy Lottery line\n" +
                "[4] - Exit"
                );
            string userInput = Console.ReadLine();

            if(userInput == "1")
            {
                Console.Clear();
                Userprofile();
            }
            else if (userInput == "2")
            {
                Console.Clear();
                UserHistory();
            }

            else if (userInput == "3")
            {
                Console.Clear();
                UserChooseOption();
            }
            Console.Clear();
        }


        public static void UserChooseOption()
        {
            // userInterface: Rohullah Karimi 2020
            string option;
            Console.WriteLine("Choose your option\n [1] Completed line \n [2] Choose your numbers");
            option = Console.ReadLine();
            if (option == "1")
            {
                UserChooseNumbers.ProgramGuessNumbersForUser();
                UserChooseNumbers.AddToJson();
            }
            else if (option == "2")
            {
                UserChooseNumbers.AskUserForFiveNumbers();
                UserChooseNumbers.AddToJson();
            }
            else
            {
                Console.WriteLine("Choose 1 or 2 to continue");
            }
            Console.Clear();
        }

        public static void UserHistory()
        {
            List<UserChooseNumbers> LottoNumberList = new List<UserChooseNumbers>();

            string result = JsonHandling.JsonRead("../../../UserLotteryNumbers.json");

            LottoNumberList = JsonConvert.DeserializeObject<List<UserChooseNumbers>>(result);


            Console.WriteLine($"Date\t\tNumbers\t\t\tStatus");
            Console.WriteLine("-------------------------------------------------");

            foreach (var item in LottoNumberList)
            {
                if (item.userID == UserProfile.currentId)
                {
                    string status;
                    if (item.status == true)
                    {
                        status = "Win";
                    }
                    else if (item.status == false)
                    {
                        status = "Loss";
                    }
                    else
                    {
                        status = "Not drawn";
                    }

                    string s = $"{item.date}" + $"\t" + $"{String.Join(", ", item.userLotteryNumber)}" + "     \t" + $"{status}";
                    Console.Write(s);
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
            Console.Clear();
        }

        public static void Userprofile()
        {
            string result = JsonHandling.JsonRead("../../../Users.json");


            dynamic dynJson = JsonConvert.DeserializeObject(result);
            Console.WriteLine("User Profile");
            Console.WriteLine("-------------------------");


            foreach (var item in dynJson)
            {
                if(item.id == UserProfile.currentId)
                {
                    string s = $"Username:\t{item.name}" + "\n" + $"Age:\t\t{item.age}" + "\n" + $"Phone:   \t{item.phone}" + "\n" + $"Email:\t\t{item.email}" + "\n" + $"Balance:\t{item.balance} $";
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine("\n[1]Add balance");
            
            string userInput = Console.ReadLine();

            if(userInput == "1")
            {
                Console.WriteLine("How much do you want to add?: ");
                    int input = Convert.ToInt32(Console.ReadLine());

                UserProfile.Balance(input, true);
                
            }
            userInput = null;
        }
    }
}




