using System.Collections.Generic;

namespace Employees.Services
{
    using System;
    using Employees.Models;
    using AutoMapper;
    using Employees.DataModels;
    using Contracts;
    using Employees.Data;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper.QueryableExtensions;

    public class EmployeeService : IEmployeeService
    {

        private readonly EmployeesContext context;

        public EmployeeService(EmployeesContext context)
        {
            this.context = context;
        }
        
        public EmployeeDto ById(int id)
        {
            var employee = context.Employees.Find(id);

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public void AddEmployee(EmployeeDto employeeDto)
        {
            var employee = Mapper.Map<Employee>(employeeDto);

            //var employee = new Employee(employeeDto.FirstName, employeeDto.LastName, employeeDto.Salary);

            context.Employees.Add(employee);

            context.SaveChanges();
        }

        public EmployeeDto SetBirthDay(int id, DateTime birthDay)
        {
            var employee = context.Employees.Find(id);

            employee.BirthDay = birthDay;

            context.SaveChanges();

            return Mapper.Map<EmployeeDto>(employee);
        }

        public EmployeeDto SetAddress(int id, string address)
        {
            var employee = context.Employees.Find(id);

            employee.Address = address;

            context.SaveChanges();

            return Mapper.Map<EmployeeDto>(employee);
        }

        public EmployeePersonalDto EmployeePersonalInfo(int id)
        {
            var employee = context.Employees.Find(id);

            return Mapper.Map<EmployeePersonalDto>(employee);
        }

        public EmployeeDto EmployeeInfo(int id)
        {
            var employee = this.ById(id);

            return Mapper.Map<EmployeeDto>(employee);
        }

        public string SetManager(int employeeId, int managerId)
        {
            var employee = context.Employees.Find(employeeId);

            employee.ManagerId = managerId;

            var manager = context.Employees.Find(managerId);
            //employee.Manager = manager;

            context.SaveChanges();

            return $"Employee {employee.FirstName} {employee.LastName} now has a manager {manager.FirstName} {manager.LastName}";
        }

        public ManagerDto ManagerInfo(int id)
        {
            //var manager = context.Employees.Include(e => e.Employees).SingleOrDefault(e => e.Id == id);

            var manager = context.Employees.Where(e => e.Id == id).Include(e => e.Employees).SingleOrDefault();

            return Mapper.Map<ManagerDto>(manager);
        }

        public ICollection<EmployeeWorkDto> EmployeesOlderThan(int age)
        {
            //might only take the years 
            var employeesOlderThan = context.Employees
                .Where(e => e.BirthDay.HasValue && e.BirthDay.Value < DateTime.Now.AddYears(-age)) //-age !?
                .Include(e => e.Manager)
                .OrderByDescending(e => e.Salary)
                .ToArray(); 

            var employeesProjected = new List<EmployeeWorkDto>();

            foreach (Employee employee in employeesOlderThan)
            {
                var mappedEmployee = Mapper.Map<Employee, EmployeeWorkDto>(employee);

                employeesProjected.Add(mappedEmployee);
            }

            return employeesProjected;
        }
    }
}