using Microsoft.AspNetCore.Mvc;
using RestASPNET.Api.Model;
using RestASPNET.Api.Services;

namespace RestASPNET.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService) 
    {
        _personService = personService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Person>> FindAll()
    {
        var pessoas = _personService.FindAll();

        return Ok(pessoas);
    }

    [HttpGet("{id}")]
    public ActionResult<Person> FindById(int id)
    {
        var pessoa = _personService.FindById(id);

        if (pessoa is null)
        {
            return BadRequest();
        }

        return Ok(pessoa);
    }
}
