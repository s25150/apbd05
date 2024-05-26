using apbd05.Context;
using apbd05.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apbd05.Controllers;

[Route("api/clients")]
[ApiController]
public class ClientsController : ControllerBase
{
    [HttpDelete("{idClient:int}")]
    public async Task<IActionResult> DeleteClient(int idClient)
    {
        var dbContext = new Apbd05Context();

        var clientToRemove = new Client()
        {
            IdClient = idClient
        };

        dbContext.Clients.Attach(clientToRemove);
        
        var hasTrips = await dbContext.ClientTrips.AnyAsync(ct => ct.IdClient == idClient);
        if (hasTrips)
        {
            return BadRequest("Cannot delete client with assigned trips.");
        }

        //var client = await dbContext.Clients.FindAsync(idClient);
        dbContext.Clients.Remove(clientToRemove);
        
        await dbContext.SaveChangesAsync();
        
        return Ok();
    }
}