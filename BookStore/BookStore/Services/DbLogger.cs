﻿using System;

namespace BookStore.Services
{
    public class DbLogger:ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("Db logger - ", message);
        }
    }
}
