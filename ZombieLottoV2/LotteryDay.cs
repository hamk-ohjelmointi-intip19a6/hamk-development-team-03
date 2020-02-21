﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace ZombieLottoV2
{
    public class LotteryDay
    {
        static double receivedMoney { get; set; }
        public static int[] zombieLottoLineNumber;
        public int[] lineNumber;
        public string date;

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
                zombieLottoLineNumber = zombieLottolineNumber;  
            }
        }

        public static void AddToJson()
        {
            string path = "../../../LotteryDay.json";
            List<LotteryDay> LottoNumberList = new List<LotteryDay>();

            //-- Get all existing lottery numbers -- 
            string result = string.Empty;

            using (StreamReader r = new StreamReader(path))
            {
                result = r.ReadToEnd();
                r.Close();
            }

            LottoNumberList = JsonConvert.DeserializeObject<List<LotteryDay>>(result);

            // New existing lottery numbers          
            LotteryDay NewLottoNumbers = new LotteryDay();
            NewLottoNumbers.lineNumber = zombieLottoLineNumber;
            NewLottoNumbers.date = DateTime.Today.ToString("dd/MM/yyyy");
            LottoNumberList.Add(NewLottoNumbers);

            //-- Writes all lottery numbers into LotteryDay.json file
            string jsonString = JsonConvert.SerializeObject(LottoNumberList, Formatting.Indented);

            using (StreamWriter r = new StreamWriter(path))
            {
                r.WriteLine(jsonString);
                r.Close();
            }
        }
    }
}
