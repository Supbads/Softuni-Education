using System;
using System.Collections.Generic;
using System.Text;
using Problem_3.Company_Hierarchy.Interfaces;

namespace Problem_3.Company_Hierarchy.Modules
{
    class Developer : RegularEmployee, IDeveloper
    {
        public Developer(string firstName, string lastname, int id, decimal salary, string department, ISet<Project> projects = null)
            : base(firstName, lastname, id, salary, department)
        {
            this.Projects = projects ?? new HashSet<Project>();
        }

        public ISet<Project> Projects { get; set; }

        public void AddProjects(ISet<Project> projects)
        {
            foreach (Project project in projects)
            {
                Projects.Add(project);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{1} {2} Salary: {3} Department: {4} {0}", Environment.NewLine,this.FirstName,this.LastName,this.Salary,this.Department);
            foreach (IProject project in Projects)
            {
                sb.AppendFormat("Project:{1} Start date:{2} State:{3}{0}",Environment.NewLine,project.ProjectName,project.ProjectStartDate,project.State);
            }
            return sb.ToString();
        }
    }
}
