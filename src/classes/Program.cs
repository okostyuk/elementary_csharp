using System;

namespace csharp1.classes
{
    class Program
    {
        static void start()
        {
            Console.WriteLine("Task1:");
            Address address = new Address();
            address.index = "49000";
            address.appartment = "2";
            address.city = "Dnipro";
            address.country = "Ukraine";
            address.house = "1A";
            
            Console.WriteLine(address);

            Console.WriteLine("Task2:");
            Rectangle recatangle = new Rectangle(2,3);
            Console.WriteLine(
                "Perimeter = " + recatangle.PerimeterCalculator() + "\n" + 
                "Area = "+ recatangle.AreaCalculator().ToString()
            );

            Console.WriteLine("Task3:");
            Book book = new Book("Louis", "Shards of honor", "Chapter One");
            book.Show();

            Console.WriteLine("Task4:");
            Figure triangle = new Figure(
                new Point("A", 0, 0),
                new Point("B", 2, 0), 
                new Point("C", 0, 3) 
            );
            triangle.PerimeterCalculator();
            Console.WriteLine(triangle);

            Console.WriteLine("Task5:");
            Console.WriteLine(new User("someLogin", "SomeName", "name2", 99));

            Console.WriteLine("Task6:");
            Converter converter = new Converter(24, 30, 0.5);
            Console.WriteLine(String.Format("25 uah to usd = {0:C2}", converter.FromUah(25, Currency.USD)));

            Console.WriteLine("Task7:");
            Employee employee = new Employee("Oleg", "Kostiuk");
            double salary;
            double tax;
            Position position = Position.DEVELOPER;
            Employee.GetSallary(position, 2, out salary, out tax);
            Console.WriteLine(employee + "\t" + position + "\t" + salary + "\t" + tax);

            Console.WriteLine("Task8:");
            

        }
    }
}
