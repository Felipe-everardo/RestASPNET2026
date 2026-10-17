namespace RestASPNET.Api.Model;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;

    public Person(int id, string firstName, string lastName, string adress, string gender)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = adress;
        Gender = gender;
    }
}