using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using webapi;
namespace webapi.Controllers;

[ApiController]
[Route("/")]
[EnableCors("MainPolicy")]
public class TehulaController : ControllerBase
{
    private readonly ILogger<TehulaController> _logger;
    private readonly TehulaService tehulaService;
    public TehulaController(ILogger<TehulaController> logger, TehulaService service)
    {
        _logger = logger;
        tehulaService = service;
    }

    [HttpGet]
   public Task<List<Tehula>> Get()
    {
        return tehulaService.GetAll();
    }

    [HttpPost("/add-tehula",Name ="/add-tehula")]
    public Task AddTehula([FromBody] Tehula tehula)
    {
        Guid guid = Guid.NewGuid(); 
        tehula._id = guid.ToString();
        return tehulaService.Add(tehula);
    }

    [HttpDelete("/delete-tehula/{id}", Name = "/delete-tehula")]
    public Task DeleteTehula(string id)
    {
        return tehulaService.Remove(id);
    }

    [HttpGet("/read-tehula/{id}", Name = "/read-tehula")]
    public Task<Tehula> ReadTehula(string id)
    {
        return tehulaService.Get(id);
    }

    [HttpPut("/update-tehula/{id}", Name = "/update-tehula")]
    public Task UpdateTehula(string id, [FromBody] Tehula tehula)
    {
        tehula._id = id;
        return tehulaService.Update(tehula);
    }



}
