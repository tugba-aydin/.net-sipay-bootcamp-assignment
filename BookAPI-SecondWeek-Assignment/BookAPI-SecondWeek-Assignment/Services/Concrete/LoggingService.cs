﻿using BookAPI_SecondWeek_Assignment.Services.Abstract;

namespace BookAPI_SecondWeek_Assignment.Services.Concrete
{
    public class LoggingService : ILoggingService
    {
        // Written for Global Logging
        public void Start()
        {
             Console.WriteLine("Action Start");
        }
        public void End()
        {
            Console.WriteLine("Action End");
        }
    }

}
