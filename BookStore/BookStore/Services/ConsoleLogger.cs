using System;

namespace BookStore.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("Console logger - ",message);
        }
    }
}
