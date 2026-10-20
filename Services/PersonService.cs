using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestASPNET.Api.Data;
using RestASPNET.Api.DTO;
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

    public List<PersonResponse> FindAll()
    {
        var listaPessoas = _context.Persons.ToList();

        return listaPessoas.Select(p => ToResponse(p)).ToList();
    }

    public PersonResponse FindById(int id)
    {
        var pessoaRecuperada = _context.Persons.FirstOrDefault(x => x.Id == id);

        if (pessoaRecuperada is null)
        {
            throw new NotFoundException("não foi possível encontrar tal pessoa");
        }

        return ToResponse(pessoaRecuperada);
    }

    public PersonResponse Create(PersonRequest request)
    {
        var person = new Person(
            id: 0,
            firstName: request.FirstName,
            lastName: request.LastName,
            address: request.Address,
            gender: request.Gender);

        _context.Persons.Add(person);
        _context.SaveChanges();

        return ToResponse(person);
    }


    public PersonResponse? Update(int id, PersonRequest request)
    {
        var person = _context.Persons.FirstOrDefault(x => x.Id == id);

        if (person is null)
        {
            return null;
        }

        person.AtualizarDados
        (
            request.FirstName,
            request.LastName,
            request.Address,
            request.Gender
        );

        _context.SaveChanges();

        return ToResponse(person);

    }

    public Person? Delete(int id)
    {
        var item = _context.Persons.Find(id);
        if (item == null)
        {
            return null;
        }
        _context.Persons.Remove(item);

        _context.SaveChanges();

        return item;
    }

    private static PersonResponse ToResponse(Person person)
    {
        return new PersonResponse
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Address = person.Address,
            Gender = person.Gender
        };
    }
}