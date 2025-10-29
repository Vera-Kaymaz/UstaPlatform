using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain.Entities;

public class Citizen
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Contact { get; init; }
    public required string Location { get; init; }
    public DateTime RegistrationDate { get; init; } = DateTime.Now;

    public Citizen() { }

    public Citizen(string name, string contact, string location)
    {
        Name = name;
        Contact = contact;
        Location = location;
    }
}