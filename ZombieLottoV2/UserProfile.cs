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
        public static int userId;
        public static string username = "admin";
        public static string userPassword = "admin";
        public static int userAge;
        public static string userPhone;
        public static string userEmail;

        static string filepath = "../../../Users.json";

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
            User jsonObject = JsonConvert.DeserializeObject<User>(result);
            //Console.WriteLine(jsonObject);

            if (jsonObject.name == username && jsonObject.password == password)
            {
                StartUserInterface.successfulSignIn = true;
                userId = 0;
            }
            else
            {
             //   MessageBox.Show("Wrong Username or Password", "Error");
            }
        }
    }
}
