using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace ZombieLottoV2
{
    class UserProfile
    {
        public static string validUsername = "admin";
        public static string validPassword = "admin";

        public static int userId;
        public static string username = "admin";
        public static string userPassword = "admin";
        public static int userAge;
        public static string userPhone;
        public static string userEmail;

        public static void SignUp(string signUpUsername, string signUpPassword, int signUpAge, string signUpPhone, string signUpEmail)
        {
            User user = new User();
            validUsername = signUpUsername;
            validPassword = signUpPassword;

            user.name = signUpUsername;
            user.password = signUpPassword;
            user.age = signUpAge;
            user.age = signUpAge;
            user.phone = signUpPhone;
            user.email = signUpEmail;

            string jsonObject = JsonConvert.SerializeObject(user);
            //Console.WriteLine(jsonObject);

        }

        public static void SignIn(string username, string password)
        {
            if (username == validUsername && password == validPassword)
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
