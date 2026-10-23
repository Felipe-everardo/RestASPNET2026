using RestASPNET.Api.DTO;
using RestASPNET.Api.Repositories;

namespace RestASPNET.Api.Services.Impl;

public class PersonServiceImpl : IPersonService
{
    private readonly IPersonRepository _repository;

    public PersonServiceImpl(IPersonRepository repository)
    {
        _repository = repository;
    }

    public List<PersonResponse> FindAll()
    {
        return _repository.FindAll();
    }

    public PersonResponse FindById(int id)
    {
        return _repository.FindById(id);
    }


    public PersonResponse Create(PersonRequest request)
    {
        return _repository.Create(request);
    }


    public PersonResponse? Update(int id, PersonRequest request)
    {
        return _repository.Update(id, request);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}