using RestASPNET.Api.DTO;

namespace RestASPNET.Api.Repositories
{
    public interface IPersonRepository
    {
        List<PersonResponse> FindAll();
        PersonResponse FindById(int id);
        PersonResponse Create(PersonRequest request);
        PersonResponse? Update(int id, PersonRequest request);
        void Delete(int id);
    }
}
