using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ZombieLottoV2
{

    public class UserHistory //Eerika
    {

        public static void CheckNumbers()
        {
            string LotteryNumbers = JsonHandling.JsonRead("../../../LotteryDay.json");

            string UserNumbers = JsonHandling.JsonRead("../../../UserLotteryNumbers.json");


            //-- check status (false, true, null) --
            List<UserChooseNumbers> List = new List<UserChooseNumbers>();

            List<UserChooseNumbers> listJson = JsonConvert.DeserializeObject<List<UserChooseNumbers>>(UserNumbers);

            foreach (var item in listJson)
            {
                if (item.status == null)
                {
                    List.Add(item);
                }
            }


            //-- fetch last object from LotteryDay.json & the numbers --
            List<int> LotteryList = new List<int>();

            List<LotteryDay> lineList = JsonConvert.DeserializeObject<List<LotteryDay>>(LotteryNumbers);

            LotteryDay lastObj = lineList[lineList.Count - 1];

            for (int i = 0; i < lastObj.lineNumber.Length; i++)
            {
                LotteryList.Add(lastObj.lineNumber[i]);
            }


            //-- compare the numbers --
            foreach (var item in List)
            {
                int point = 0;
                bool? WinOrLose;

                for (int i = 0; i < item.userLotteryNumber.Length; i++)
                {
                    for (int n = 0; n < LotteryList.Count; n++)
                    {
                        if (item.userLotteryNumber[i] == LotteryList[n])
                        {
                            point++;
                        }
                    }
                }

                if (point == 5)
                {
                    WinOrLose = true;
                }
                else
                {
                    WinOrLose = false;
                }

                Console.WriteLine(WinOrLose);

                //-- status change --

            }

        }
    }
}
