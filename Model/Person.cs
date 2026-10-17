namespace RestASPNET.Api.Model;

public class Person
{
    public int Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public string Gender { get; private set; } = string.Empty;

    public Person(int id, string firstName, string lastName, string address, string gender)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Gender = gender;
    }
}