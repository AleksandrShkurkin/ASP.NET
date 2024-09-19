public class Company
{
    public string Name {get; set;} = "";
    public int YearOfCreation {get; set;}
    public string Value {get; set;} = "";
    public int AmountOfWorkers {get; set;}

    public Company(string name, int yearOfCreation, string value, int amountOfWorkers)
    {
        Name = name;
        YearOfCreation = yearOfCreation;
        Value = value;
        AmountOfWorkers = amountOfWorkers;
    }
}