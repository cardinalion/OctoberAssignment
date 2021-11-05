using System;

namespace AssignmentTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkingWithMethod wm = new WorkingWithMethod();

            int[] numbers = wm.GenerateNumbers();
            wm.Reverse(numbers);
            wm.PrintNumbers(numbers);
            int[] numbersTwo = wm.GenerateNumbers(5);
            wm.Reverse(numbersTwo);
            wm.PrintNumbers(numbersTwo);

            for (int i = 1; i <= 10; ++i)
            {
                Console.Write(wm.Fibonacci(i) + " ");
            }
            Console.WriteLine();

            int totalWorkingDays = wm.CountWorkingDays("/01-01-1990/", "/12-31-2020/");
            Console.WriteLine($"Total working days are " + totalWorkingDays);

            Department cs = new Department("CS");
            Course cs101 = new Course("CS101");
            Instructor profA = new Instructor("profA", 1, 1, 1980, 10000, cs, 1, 1, 2010);
            Student amy = new Student("amy", 1, 1, 1990, 1000);

            ManageDepartment md = new ManageDepartment();
            md.ChangeHead(cs, profA);
            md.AddCourses(cs, cs101);
            ManageCourse mc = new ManageCourse();
            mc.AddStudent(cs101, amy);

            ManageInstructor mi = new ManageInstructor();
            Console.WriteLine(mi.CalcSalary(profA) + " USD/yr");
            ManageStudent ms = new ManageStudent();
            ms.AddCourse(amy, cs101, 'A');
            Console.WriteLine(ms.CalcGPA(amy));

            Ball b = new Ball(0, 0, 255, 1);
            Console.WriteLine(b.color.GetGreyscale());
            b.Throw();
            Console.WriteLine(b.thrownTimes);
            b.Pop();
            b.Throw();
            Console.WriteLine(b.thrownTimes);

            // instantialize a customer c
            Customer c = new Customer("Adam", "Smith", "adamsmith@example.com");
            // c add an order
            c.AddNewOrder("An apple");
            c.AddNewOrder("A banana");
            // check c historic order
            c.PrintHistoricOrders();
            // try adding a null order
            c.AddNewOrder();
            // try adding a order with existing id
            c.AddNewOrder("Two apples", 1, 1, 2020, 1);
            c.PrintHistoricOrders();
            // add an order in the future
            c.AddNewOrder("An orange", 1, 1, 2025);
            c.PrintHistoricOrders();
        }
    }
}
