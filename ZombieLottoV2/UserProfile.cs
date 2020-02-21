using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ZombieLottoV2
{
    class UserProfile
    {
        public static int currentId;

        static string filepath = "../../../Users.json";
        static string path = "../../../LotteryDay.json";

        public static void SignUp(string signUpUsername, string signUpPassword, int signUpAge, string signUpPhone, string signUpEmail)
        {
            List<User> list = new List<User>();

            //-- Get all existing users from json -- 
            string result = string.Empty;
            using (StreamReader r = new StreamReader(filepath))
            {
                result = r.ReadToEnd();
                r.Close();
            }

            dynamic dynJson = JsonConvert.DeserializeObject(result);

            foreach (var item in dynJson) 
            {
                User userOld = new User();
                userOld.name = item.name;
                userOld.password = item.password;
                userOld.age = item.age;
                userOld.phone = item.phone;
                userOld.email = item.email;

                list.Add(userOld);
            }
            //-- New user account --            
            User user = new User();

            user.name = signUpUsername;
            user.password = signUpPassword;
            user.age = signUpAge;
            user.age = signUpAge;
            user.phone = signUpPhone;
            user.email = signUpEmail;
 
            list.Add(user);

            //-- Writes all users into json file
            string jsonString = JsonConvert.SerializeObject(list, Formatting.Indented);

            using (StreamWriter r = new StreamWriter(filepath))
            {
                r.WriteLine(jsonString);
                r.Close();
            }
           
        }

        public static void SignIn(string username, string password)
        {
            string result = string.Empty;
            using (StreamReader r = new StreamReader(filepath))
            {
                result = r.ReadToEnd();
                r.Close();
            }
            dynamic dynJson = JsonConvert.DeserializeObject(result);

            foreach (var item in dynJson)
            {
                if(item.name == username && item.password == password)
                {
                    currentId = item.id;
                    StartUserInterface.successfulSignIn = true;
                    //Console.WriteLine(Convert.ToString(item.id));
                }
            }

            if (StartUserInterface.successfulSignIn == false)
            {
                Console.WriteLine("Wrong username or password");
            }
        }

        public static void Jee()
        {
            string result = string.Empty;
            using (StreamReader r = new StreamReader(path))
            {
                result = r.ReadToEnd();
                r.Close();
            }
            LotteryDay numJson = JsonConvert.DeserializeObject<LotteryDay>(result);
            Console.WriteLine(Convert.ToString(numJson.numOne));
        }
    }
}
