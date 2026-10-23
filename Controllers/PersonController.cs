using Microsoft.AspNetCore.Mvc;
using RestASPNET.Api.DTO;
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
    public ActionResult<IEnumerable<PersonResponse>> FindAll()
    {
        var pessoas = _personService.FindAll();

        return Ok(pessoas);
    }

    [HttpGet("{id}")]
    public ActionResult<PersonResponse> FindById(int id)
    {
        var pessoa = _personService.FindById(id);

        if (pessoa is null)
        {
            return NotFound();
        }

        return Ok(pessoa);
    }

    [HttpPost]
    public ActionResult<PersonResponse> Create([FromBody] PersonRequest request)
    {
        var response = _personService.Create(request);

        return CreatedAtAction(nameof(FindById), new {id = response.Id}, response);
    }

    
    [HttpPut("{id}")]
    public ActionResult<PersonResponse> Update(int id, [FromBody] PersonRequest request)
    {
        var response = _personService.Update(id, request);

        if (response is null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
         _personService.Delete(id);

        return NoContent();
    }
}
