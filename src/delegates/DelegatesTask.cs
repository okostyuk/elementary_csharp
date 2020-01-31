using System;

namespace csharp1.delegates
{
    public static class DelegatesTask
    {

        //Task 1
        private delegate int Task1Delegate(int a, int b, int c);
        private static Task1Delegate delegateInstance = delegate(int a, int b, int c) { return (a + b + c) / 3; };

        //Task 2
        private delegate int Task2Delegate(int a, int b);

        static Task2Delegate AddDel = (a, b) => a + b;
        static Task2Delegate SubDel = (a, b) => a - b;
        static Task2Delegate MulDel = (a, b) => a * b;
        static Task2Delegate DivDel = (a, b) => b == 0 ? throw new Exception("Do not divide by ZERO") : a / b;

        private enum MathAction
        {
            Add,
            Sub,
            Mul,
            Div
        }

        public static void Task2()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Add|Sub|Mul|Div value1 value2");
                    String input = Console.ReadLine();
                    
                    if ("q".Equals(input))
                    {
                        return;
                    }

                    String[] inputValues = input.Split(" ");
                    int value1 = ParseValue(inputValues[1]);
                    int value2 = ParseValue(inputValues[2]);

                    if (!Enum.TryParse(inputValues[0], out MathAction selectedAction))
                    {
                        throw new Exception("Invalid action " + inputValues[0] + " allowed only: Add, Sub, Mul, Div");
                    }

                    switch (selectedAction)
                    {
                        case MathAction.Add:
                            Console.WriteLine(AddDel.Invoke(value1, value2));
                            break;
                        case MathAction.Sub:
                            Console.WriteLine(SubDel.Invoke(value1, value2));
                            break;
                        case MathAction.Mul:
                            Console.WriteLine(MulDel.Invoke(value1, value2));
                            break;
                        case MathAction.Div:
                            Console.WriteLine(DivDel.Invoke(value1, value2));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private static int ParseValue(String input)
        {
            if (!Int32.TryParse(input, out var result))
            {
                throw new Exception("Invalid first value: " + input + " numbers only allowed");
            }

            return result;
        }


        //task3
        private delegate int IntResultDelegate();

        private delegate int Task3Delegate(IntResultDelegate[] items);

        private static readonly Task3Delegate Task3DelegateInstance = delegate(IntResultDelegate[] items)
        {
            int sum = 0;
            foreach (var item in items)
            {
                int itemVal = item.Invoke();
                Console.Write(itemVal + " ");
                sum += itemVal;
            }
            Console.WriteLine("Sum: " + sum);
            int result = sum / items.Length;
            Console.WriteLine("Result: " + result);
            return result;
        };

        public static void Task3()
        {
            IntResultDelegate[] items =
            {
                () => new Random().Next(1, 10),
                () => new Random().Next(1, 10),
                () => new Random().Next(1, 10)
            };

            Task3DelegateInstance.Invoke(items);
        }
    }
}