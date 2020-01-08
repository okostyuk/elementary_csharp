using System;
using System.Collections.Generic;

namespace csharp1.classes 
{
    class Employee
    {
        private static Dictionary<Position, double> position2salary = new Dictionary<Position, double>();
        private static double experienceMultiplier = 0.5;
        private static double taxPercent = 0.35;

        static Employee() 
        {
            position2salary.Add(Position.DEVELOPER, 100);
            position2salary.Add(Position.MANAGER, 200);
            position2salary.Add(Position.QA, 300);
        }

        private readonly String fName, lName;

        public Employee(String fName, String lName) {
            this.fName = fName;
            this.lName = lName;
        }

        override public String ToString() {
            return fName + " " + lName;
        }

        public static void GetSallary(Position position, int expYeas, out double salary, out double tax) {
            if (position2salary.TryGetValue(position, out salary)) {
                salary = salary + (salary*expYeas*experienceMultiplier);
                tax = salary * taxPercent;
                return;
            };

            throw new Exception();
        }
    }

    enum Position {
        DEVELOPER, MANAGER, QA
    }
}