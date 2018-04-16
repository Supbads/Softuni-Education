using System;

namespace Problem_3.Company_Hierarchy.Interfaces
{
    interface IProject
    {
        string ProjectName { get; set; }
        DateTime ProjectStartDate { get; set; }
        string Details { get; set; }
        ProjectState State { get; set; }
        void CloseProject();

    }
}
