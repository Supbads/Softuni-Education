namespace Problem_3.Company_Hierarchy.Interfaces
{
    interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Id { get; set; }
        string ToString();
    }
}
