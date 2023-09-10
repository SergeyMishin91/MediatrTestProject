using DemoLibrary.Models;

namespace DemoLibrary.DataAccess;

public class DemoDataAccess : IDataAccess
{
    private List<PersonModel> people = new();

    public DemoDataAccess()
    {
        people.Add(new PersonModel() { Id = 1, FirstName = "Vasya", LastName = "Ivanov" });
        people.Add(new PersonModel() { Id = 2, FirstName = "Sasha", LastName = "Petrov" });
    }

    public List<PersonModel> GetPeople()
    {
        return people;
    }
    
    public PersonModel CreatePerson(string firstName, string lastName)
    {
        var p = new PersonModel()
        {
            Id = people.Max(p => p.Id) + 1,
            FirstName = firstName,
            LastName = lastName
        };

        people.Add(p);

        return p;
    }
}
