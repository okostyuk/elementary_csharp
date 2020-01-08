using System;

namespace csharp1.classes
{
    class User
    {
        private readonly String login, fName, sName;
        private readonly int age;
        private readonly DateTime date;

        public User(String login, String fName, String sName, int age) {
            this.login = login;
            this.fName = fName;
            this.sName = sName;
            this.age = age;
            this.date = DateTime.UtcNow;
        }

        override public String ToString() {
            return login + " " + fName + " " + sName + " " + age + " " + date; 
        } 
    }
}