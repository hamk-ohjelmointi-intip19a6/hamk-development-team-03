using System;


namespace ZombieLotto
{

    /*TODO:
     *
     *  
     * this is test commit
     *
     *this is test
     * 
     *
     * */
    class program
    {
        public static void Main(string[] args)
        {
            StartUserInterface.startmenu();
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
            // end of userInterface
        }
    } 
}
