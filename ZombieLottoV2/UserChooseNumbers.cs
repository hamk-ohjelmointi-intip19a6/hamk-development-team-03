using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ZombieLottoV2
{
    public class UserChooseNumbers
    {
        public static int[] lineNumber;
        public int userID;
        public string date;
        public int[] userLotteryNumber;
        public bool? status;
        

        public static void ProgramGuessNumbersForUser()
        {
           
            lineNumber = new int[5];
            Random randomNumbers = new Random();

            for (int round = 0; round < 5; round++)
            {
                int num = randomNumbers.Next(1, 25);
                lineNumber[round] = num;
            }
            Console.WriteLine("Program guessed line number is: " + "{0}", string.Join(", ", lineNumber));
            UserProfile.Balance(2.0, false);
            Console.ReadLine();
        }

        public static void AskUserForFiveNumbers()
        {
            lineNumber = new int[5];

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
            Console.WriteLine("Your line number is: " + "{0}", string.Join(", ", lineNumber));
            UserProfile.Balance(2.0, false);
            Console.ReadLine();
        }

        public static void AddToJson()
        {
            string path = "../../../UserLotteryNumbers.json";
            List<UserChooseNumbers> LottoNumberList = new List<UserChooseNumbers>();

            //-- Get all existing lottery numbers -- 
            string result = string.Empty;

            using (StreamReader r = new StreamReader(path))
            {
                result = r.ReadToEnd();
                r.Close();
            }

            LottoNumberList = JsonConvert.DeserializeObject<List<UserChooseNumbers>>(result);

            // New existing lottery numbers          
            UserChooseNumbers NewLottoNumbers = new UserChooseNumbers();
            NewLottoNumbers.userID = UserProfile.currentId;
            NewLottoNumbers.userLotteryNumber = lineNumber;
            NewLottoNumbers.date = DateTime.Today.ToString("dd/MM/yyyy");
            NewLottoNumbers.status = null;
            LottoNumberList.Add(NewLottoNumbers);

            //-- Writes all lottery numbers into LotteryDay.json file
            string jsonString = JsonConvert.SerializeObject(LottoNumberList, Formatting.Indented);

            using (StreamWriter r = new StreamWriter(path))
            {
                r.WriteLine(jsonString);
                r.Close();
            }
            Console.WriteLine(lineNumber);
        }

    }
}
