using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ZombieLottoV2
{
    public class LotteryDay
    {

        public int numOne = 2;
        public int numTwo = 3;
        public int numThree = 4;
        public int numFour = 5;
        public int numFive = 6;


        static double receivedMoney { get; set; }

        public static double ReceivedMoney()
        {
            // this is test value for receivedMoney 
            receivedMoney = 10.00;
            return receivedMoney;
        }

        public static void LotteryNumber()
        {
            LotteryDay receivedMoney = new LotteryDay();

            double getMoneyValue = LotteryDay.ReceivedMoney();
            if (getMoneyValue >= 10)
            {
                // guess the 5 numbers
                int[] zombieLottolineNumber = new int[5];
                Random randomNumbers = new Random();

                for (int round = 0; round < 5; round++)
                {
                    int num = randomNumbers.Next(1, 25);
                    zombieLottolineNumber[round] = num;
                }
                Console.WriteLine("ZombieLotto line number: " + "{0}", string.Join(", ", zombieLottolineNumber));
            }

        }

        public static void AddToJson()
        {
            LotteryDay lotteryday = new LotteryDay();
            string JSONresult = JsonConvert.SerializeObject(lotteryday);
            string path = "../../../LotteryDay.json";

            if (File.Exists(path))
            {
                File.Delete(path);
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(JSONresult.ToString());
                    tw.Close();
                }
            }
            else if (!File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(JSONresult.ToString());
                    tw.Close();
                }
            }
        }

    }
}
