using System;
using System.Globalization;

namespace csharp1.structures
{
    public static class Program
    {
        public static void task2()
        {
            Train[] trains = new Train[8];
            for (int i = 0; i < trains.Length; i++)
            {
                Console.WriteLine("Train " + i + ":");
                Console.Write("Number: ");
                String inputNumber = Console.ReadLine();
                int numValue;
                while (!Int32.TryParse(inputNumber, out numValue))
                {
                    Console.WriteLine("Invalid value");
                    Console.Write("Number: ");
                    inputNumber = Console.ReadLine();
                }
                
                Console.Write("Destination : ");
                String inputDestination = Console.ReadLine();
                
                Console.Write("Departure time (dd MM yyyy): ");
                String inputDate = Console.ReadLine();

                DateTime departureTimeResult;
                while (!DateTime.TryParseExact(
                        inputDate, 
                        "dd MM yyyy", 
                        null, 
                        DateTimeStyles.None, 
                        out departureTimeResult))
                {
                    Console.WriteLine("Invalid value");
                    Console.Write("Departure time (mm.dd.yyyy): ");
                    inputDate = Console.ReadLine();
                }

                trains[i] = new Train(numValue, inputDestination, departureTimeResult);
            }
            
            Array.Sort(trains, (train, train1) => train.number.CompareTo(train1.number));


            while (true)
            {
                Console.Write("Enter train number : ");
                String input = Console.ReadLine();
                if ("q".Equals(input))
                {
                    return;
                }

                int inputTrainNumber;
                while (!Int32.TryParse(input, out inputTrainNumber))
                {
                }

                bool found = false;
                foreach (var train in trains)
                {
                    if (train.number.Equals(inputTrainNumber))
                    {
                        Console.WriteLine(train);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Train not found");
                }
            }
        }

        public static void task3()
        {
            MyStruct struct1 = new MyStruct();
            struct1.change = "not changed";
            Console.WriteLine(struct1.change + " " + struct1.GetHashCode());
            StruktTaker(struct1);
            struct1.change = "asd";
            Console.WriteLine(struct1.change);

            MyStruct struct2 = struct1;
            Console.WriteLine(struct2.change + " " + struct2.GetHashCode());
            Console.WriteLine(struct2.Equals(struct1));
            Console.WriteLine(Object.ReferenceEquals(struct1, struct2));
        }

        static void StruktTaker(MyStruct sStruct)
        {
            sStruct.change = "changed";
            Console.WriteLine("StruktTaker: " + sStruct.change + " " + sStruct.GetHashCode());
        }
    }
}