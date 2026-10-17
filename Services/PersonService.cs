using RestASPNET.Api.Exceptions;
using RestASPNET.Api.Model;

namespace RestASPNET.Api.Services;

public class PersonService : IPersonService
{
    private static readonly List<Person> _pessoa = new List<Person>() 
    {
        new Person (1, "felipe", "Everardo", "123", "male"),
        new Person (2, "Fabrício", "Everardo", "123", "male")
    };

    public List<Person> FindAll()
    {
         var listaPessoas = _pessoa.ToList();

         return listaPessoas;
    }

    public Person FindById(int id)
    {
        var pessoaRecuperada = _pessoa.FirstOrDefault(x => x.Id == id);
        
        if (pessoaRecuperada is null)
        {
            throw new NotFoundException("não foi possível encontrar tal pessoa");
        }

        return pessoaRecuperada;
    }
}