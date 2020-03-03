using System;

namespace ZombieLottoV2
{

    /*TODO:
     *
     *  testi
     * 
     *
     *
     * 
     *
     * */
    class program
    {
        public static void Main(string[] args)
        {
            //LotteryDay.LotteryNumber();
            UserInterface.Startmenu();
            while (true)
            {
                Console.WriteLine(User.NextId);
                UserInterface.MainMenu();
            }
            //Adding or removing balance
            //UserProfile.Balance(amount, add:true|remove:false);
            //UserProfile.Balance(20.0, true);

        }
    }
}
