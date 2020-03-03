using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ZombieLottoV2
{
    public class UserProfile
    {
        public static int currentId;

        public static void SignUp(string signUpUsername, string signUpPassword, int signUpAge, string signUpPhone, string signUpEmail)
        {
            List<User> list = new List<User>();

            string result = JsonHandling.JsonRead("../../../Users.json");

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

            JsonHandling.JsonWrite("../../../Users.json", jsonString);
           
        }

        public static void SignIn(string username, string password)
        {
            string result = JsonHandling.JsonRead("../../../Users.json");

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

        public static void Balance(double amount, bool add)
        {
            double newBalance = 0;
            List<User> list = new List<User>();

            string result = JsonHandling.JsonRead("../../../Users.json");

            dynamic dynJson = JsonConvert.DeserializeObject(result);

            foreach (var item in dynJson)
            {
                if (item.id == currentId && add)
                {
                    newBalance = item.balance + amount;
                }
                else if (item.id == currentId && !add)
                {
                    newBalance = item.balance - amount;
                }
                else
                {
                    newBalance = item.balance;
                }
                User userOld = new User();
                userOld.name = item.name;
                userOld.password = item.password;
                userOld.age = item.age;
                userOld.phone = item.phone;
                userOld.email = item.email;
                userOld.balance = newBalance;


                list.Add(userOld);
            }
            string jsonString = JsonConvert.SerializeObject(list, Formatting.Indented);

            JsonHandling.JsonWrite("../../../Users.json", jsonString);
        }
    }
}
