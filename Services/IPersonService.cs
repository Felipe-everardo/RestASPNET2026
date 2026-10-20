using RestASPNET.Api.DTO;
using RestASPNET.Api.Model;

namespace RestASPNET.Api.Services;

public interface IPersonService
{
    List<PersonResponse> FindAll();
    PersonResponse FindById(int id);
    PersonResponse Create(PersonRequest request);
    PersonResponse? Update(int id, PersonRequest request);
    Person? Delete(int id);
}