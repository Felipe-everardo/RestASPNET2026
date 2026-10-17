using RestASPNET.Api.Model;

namespace RestASPNET.Api.Services;

public interface IPersonService
{
    List<Person> FindAll();
    Person FindById(int id);
}