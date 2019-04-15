using System;

namespace API.Code
{
    public class Singleton
    {
        public string Date { get; private set; }
        public static string text = "hello";
        private Singleton()
        {
            Console.WriteLine($"Singleton ctor {DateTime.Now.TimeOfDay}");
            Date = DateTime.Now.TimeOfDay.ToString();
        }

        public static Singleton GetInstance()
        {
            Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
            return Nested.instance;
        }

        private class Nested
        {
            internal static readonly Singleton instance = new Singleton();
        }
    }
}
