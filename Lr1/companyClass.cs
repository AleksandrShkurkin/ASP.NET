public class Company
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int EmployeesAmount { get; set; }
    public required int Salary { get; set; }

    public string Print()
    {
        return $"Name: {Name}\nDescription: {Description}\nEmployees: {EmployeesAmount}\nSalary: {Salary}";
    }
}