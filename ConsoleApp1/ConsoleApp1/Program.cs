using System;

namespace ConsoleApp1
{

    public class User
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class Employee : User
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            User u = new Employee();



            Console.WriteLine(u.GetType() + " " + nameof(u.GetType()));
        }
    }
}
