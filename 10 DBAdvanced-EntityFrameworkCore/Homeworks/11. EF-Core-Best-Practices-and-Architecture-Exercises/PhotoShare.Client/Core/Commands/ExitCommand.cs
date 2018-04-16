﻿namespace PhotoShare.Client.Core.Commands
{
    using Contracts;
    using System;

    public class ExitCommand : ICommand
    {
        public string Execute(params string[] data)
        {
            Console.WriteLine("Bye-bye");
            Environment.Exit(0);
            return "";
        }
    }
}