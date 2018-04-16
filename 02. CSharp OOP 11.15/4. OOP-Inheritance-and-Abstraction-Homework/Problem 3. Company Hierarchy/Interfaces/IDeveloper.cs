using System.Collections.Generic;
using Problem_3.Company_Hierarchy.Modules;

namespace Problem_3.Company_Hierarchy.Interfaces
{
    interface IDeveloper
    {
        ISet<Project> Projects { get; set; }
        void AddProjects(ISet<Project> projects);
        string ToString();
    }
}
