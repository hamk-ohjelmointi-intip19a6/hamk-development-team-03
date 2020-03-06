using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ZombieLottoV2
{
    class program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                LotteryDay.receivedMoney = LotteryDay.ReceivedMoney();
                UserInterface.Startmenu();
                while (UserInterface.successfulSignIn)
                {
                    //Console.WriteLine(User.NextId);
                    LotteryDay.LotteryNumber();
                    UserInterface.MainMenu();
                }
            }
        }
    }
}
