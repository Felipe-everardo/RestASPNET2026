using RestASPNET.Api.Data;
using RestASPNET.Api.Exceptions;
using RestASPNET.Api.Model;

namespace RestASPNET.Api.Services;

public class PersonService : IPersonService
{
    private readonly RestContext _context;

    public PersonService(RestContext restContext)
    {
        _context = restContext;
    }

    public List<Person> FindAll()
    {
         var listaPessoas = _context.People.ToList();

         return listaPessoas;
    }

    public Person FindById(int id)
    {
        var pessoaRecuperada = _context.People.FirstOrDefault(x => x.Id == id);
        
        if (pessoaRecuperada is null)
        {
            throw new NotFoundException("não foi possível encontrar tal pessoa");
        }

        return pessoaRecuperada;
    }
}