using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ZombieLottoV2
{
    public class JsonHandling
    {
        public static string JsonRead(string path)
        {
            string result = string.Empty;

            using (StreamReader r = new StreamReader(path))
            {
                result = r.ReadToEnd();
                r.Close();
            }

            return result;
        }

        public static void JsonWrite(string path, string input)
        {
            using (StreamWriter r = new StreamWriter(path))
            {
                r.WriteLine(input);
                r.Close();
            }
        }
    }
}
