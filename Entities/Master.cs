namespace UstaPlatform.Domain.Entities;

public class Master
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Expertise { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int Workload { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; } = DateTime.Now;

    // Default constructor
    public Master() { }

    // Optional constructor
    public Master(string name, string expertise, string location)
    {
        Name = name;
        Expertise = expertise;
        Location = location;
    }
}