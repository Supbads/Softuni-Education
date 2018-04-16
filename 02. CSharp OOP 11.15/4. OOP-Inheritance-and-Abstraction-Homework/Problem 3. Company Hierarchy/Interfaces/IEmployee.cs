namespace Problem_3.Company_Hierarchy.Interfaces
{
    interface IEmployee
    {
        decimal Salary { get; set; }
        string Department { get; set; }
        string ToString();
    }
}
