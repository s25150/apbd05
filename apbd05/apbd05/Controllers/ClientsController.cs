using apbd05.Context;
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

        var hasTrips = await dbContext.ClientTrips.AnyAsync(ct => ct.IdClient == idClient);
        if (hasTrips)
        {
            return BadRequest("Cannot delete client with assigned trips.");
        }

        var client = await dbContext.Clients.FindAsync(idClient);
        dbContext.Clients.Remove(client);
        await dbContext.SaveChangesAsync();
        
        return NoContent();
    }
}