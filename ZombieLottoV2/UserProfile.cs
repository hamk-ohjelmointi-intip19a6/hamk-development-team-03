using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZombieLottoV2
{
    class UserProfile
    {
        public static string validUsername = "admin";
        public static string validPassword = "admin";

        public static int userId;
        public static string username = "admin";
        public static string userPassword = "admin";
        public static string userAge;
        public static string userPhone;
        public static string userEmail;

        public static void SignUp(string signUpUsername, string signUpPassword, string signUpAge, string signUpPhone, string signUpEmail)
        {
            validUsername = signUpUsername;
            validPassword = signUpPassword;

            username = signUpUsername;
            userPassword = signUpPassword;
            userAge = signUpAge;
            userPhone = signUpPhone;
            userEmail = signUpEmail;
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
