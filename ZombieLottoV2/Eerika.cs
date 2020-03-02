using System;
using System.IO;

namespace ZombieLottoV2
{
    public class Eerika
    {
        public static void readJsonExample()
        {
            string path = "../../../LotteryDay.json";
            string result = string.Empty;

            using (StreamReader r = new StreamReader(path))
            {
                result = r.ReadToEnd();
                r.Close();
            }

            Chilkat.JsonArray jsonArray = new Chilkat.JsonArray();
            jsonArray.Load(result);

            //  Examine the values:
            int i = 0;
            while (i < jsonArray.Size)
            {
                Chilkat.JsonObject jsonObj = jsonArray.ObjectAt(i);
                Console.WriteLine(Convert.ToString(i) + ": " + jsonObj.StringOf("lineNumber"));

                i = i + 1;
            }

            //  Output is:
            /*
            0: [9,6,13,24,17]
            1: [18,21,24,19,16]
            2: [3,24,8,17,9]
            3: [23,13,19,20,19]
            4: [23,1,11,8,21]
            5: [22,13,1,5,16]
            6: [4,13,19,6,17]
            7: [20,17,9,8,11]
            8: [6,20,10,15,1]
            9: [22,2,8,6,11]
            10: [20,11,24,9,18]
            */
        }
    }
}
