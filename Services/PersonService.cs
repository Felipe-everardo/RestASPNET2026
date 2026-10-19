using RestASPNET.Api.Data;
using RestASPNET.Api.Exceptions;
using RestASPNET.Api.Model;

namespace RestASPNET.Api.Services;

public class PersonService : IPersonService
{
    private readonly MSSQLContext _context;

    public PersonService(MSSQLContext restContext)
    {
        _context = restContext;
    }

    public List<Person> FindAll()
    {
         var listaPessoas = _context.Persons.ToList();

         return listaPessoas;
    }

    public Person FindById(int id)
    {
        var pessoaRecuperada = _context.Persons.FirstOrDefault(x => x.Id == id);
        
        if (pessoaRecuperada is null)
        {
            throw new NotFoundException("não foi possível encontrar tal pessoa");
        }

        return pessoaRecuperada;
    }
}