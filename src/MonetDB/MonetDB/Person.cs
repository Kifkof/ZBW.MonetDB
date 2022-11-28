namespace MonetDB;

internal class Person
{
    public Person(int id, string name, int yearsOfExperience)
    {
        Id = id;
        Name = name;
        YearsOfExperience = yearsOfExperience;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int YearsOfExperience { get; set; }

    public override string ToString()
    {
        return $"Id: {this.Id,-3} | Name: {this.Name,-15} | Berufserfahrung: {this.YearsOfExperience}";
    }
}