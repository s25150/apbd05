using apbd05.Context;
using Microsoft.AspNetCore.Mvc;

namespace apbd05.Controllers;

[Route("api/clients")]
[ApiController]
public class ClientsController : ControllerBase
{
    [HttpDelete("{idClient:int}")]
    public async Task<IActionResult> DeleteClient()
    {
        var dbContext = new Apbd05Context();
        //var result = 
        return NoContent();
    }
}