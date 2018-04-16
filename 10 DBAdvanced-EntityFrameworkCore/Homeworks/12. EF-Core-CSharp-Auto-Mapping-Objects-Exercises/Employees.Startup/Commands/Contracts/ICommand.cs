using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Startup.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(params string[] parameters);


    }
}