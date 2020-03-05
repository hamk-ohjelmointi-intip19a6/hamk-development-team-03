﻿namespace ZombieLottoV2
{
    internal class User
    {
        public static int NextId = 0;

        public User()
        {
            id = NextId++;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public double balance { get; set; }
    }
}