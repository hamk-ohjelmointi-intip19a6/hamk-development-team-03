using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ZombieLottoV2
{
    class UserProfile
    {
        public static int currentId;

        static string filepath = "../../../Users.json";

        public static int userId;
        public static string username = "admin";
        public static string userPassword = "admin";
        public static int userAge;
        public static string userPhone;
        public static string userEmail;

        public static void SignUp(string signUpUsername, string signUpPassword, int signUpAge, string signUpPhone, string signUpEmail)
        {
            User user = new User();

            user.name = signUpUsername;
            user.password = signUpPassword;
            user.age = signUpAge;
            user.age = signUpAge;
            user.phone = signUpPhone;
            user.email = signUpEmail;

            string jsonString = JsonConvert.SerializeObject(user);

            JObject jsonObject = JObject.Parse(jsonString);

            Console.WriteLine(jsonObject);

            string result = string.Empty;
            using (StreamWriter r = new StreamWriter(filepath))
            {
                r.WriteLine(jsonObject);
                r.Close();
            }
            //File.WriteAllText(filepath, jsonString);
           
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


            /*if (jsonObject.name == username && jsonObject.password == password)
            User jsonObject = JsonConvert.DeserializeObject<User>(result);
            //Console.WriteLine(jsonObject);

            if (jsonObject.name == username && jsonObject.password == password)
            {
                StartUserInterface.successfulSignIn = true;
            }
            else
            {
             //   MessageBox.Show("Wrong Username or Password", "Error");
            }*/
        }
    }
}
