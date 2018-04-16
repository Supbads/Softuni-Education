using System;
using Problem_3.Company_Hierarchy.Interfaces;

namespace Problem_3.Company_Hierarchy.Modules
{
    class Project : IProject
    {
        private string projectName; 
        public Project(string projectName, DateTime projectStartDate, string details)
        {
            this.ProjectName = projectName;
            this.ProjectStartDate = projectStartDate;
            this.Details = details;
        }

        public string ProjectName
        {
            get { return projectName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Project name cannot be null");
                }
                if (value.Length < 1)
                {
                    throw new ArgumentException("Project name cannot be empty");
                }
                projectName = value;
            }
        }

        public DateTime ProjectStartDate { get; set; }
        public string Details { get; set; }
        public ProjectState State { get; set; }
        public void CloseProject()
        {
            this.State = ProjectState.closed;
        }
    }
}
