using System;
using System.Globalization;
using Microsoft.VisualBasic.CompilerServices;

namespace csharp1.structures
{
    public static class Program
    {
        public static void task2()
        {
            Train[] trains = new Train[8];
            for (int i = 0; i < 8; i++)
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
                
                Console.WriteLine();
                Console.Write("Destination : ");
                String inputDestination = Console.ReadLine();
                
                Console.WriteLine();
                Console.Write("Departure time (mm.dd.yyyy): ");
                String inputDate = Console.ReadLine();

                DateTime departureTimeResult;
                while (!DateTime.TryParseExact(
                        inputDate, 
                        "MM.dd.yyyy", 
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
                Console.WriteLine();
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
    }
}