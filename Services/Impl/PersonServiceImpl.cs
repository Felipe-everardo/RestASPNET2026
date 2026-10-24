using RestASPNET.Api.DTO;
using RestASPNET.Api.Repositories;

namespace RestASPNET.Api.Services.Impl;

public class PersonServiceImpl : IPersonService
{
    private readonly IPersonRepository _repository;
    private readonly ILogger<PersonServiceImpl> _logger;

    public PersonServiceImpl(IPersonRepository repository, ILogger<PersonServiceImpl> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public List<PersonResponse> FindAll()
    {
        var persons = _repository.FindAll();
        _logger.LogInformation("Retrieved {Count} persons from the repository.", persons.Count);
        return persons;
    }

    public PersonResponse FindById(int id)
    {
        var person = _repository.FindById(id);
        _logger.LogInformation("Retrieving person with ID {Id} from the repository.", id);
        return person;
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