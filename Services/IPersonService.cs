using RestASPNET.Api.DTO;

namespace RestASPNET.Api.Services;

public interface IPersonService
{
    List<PersonResponse> FindAll();
    PersonResponse FindById(int id);
    PersonResponse Create(PersonRequest request);
    PersonResponse? Update(int id, PersonRequest request);
    void Delete(int id);
}