using apbd05.Context;
using apbd05.Models;
using apbd05.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apbd05.Controllers;


[Route("api/trips")]
[ApiController]
public class TripsController : ControllerBase
{
    
    [HttpGet]
    public async Task<IActionResult> GetTrips()
    {
        var dbContext = new Apbd05Context();
        
        var tripsDesc = await dbContext.Trips
            .OrderByDescending(trip => trip.DateFrom)
            .ToListAsync(); //wymusza wykonanie zapytania do bazy w tym momencie
            
        return Ok(tripsDesc);
    }
    
    
    [HttpPost("{idTrip:int}/clients")]
    public async Task<IActionResult> AssignClientToTrip(int idTrip, AssignClientRequest acr)
    {
        var dbContext = new Apbd05Context();

        var clientToTrip = new AssignClientRequest()
        {
            IdClient = acr.IdClient,
            FirstName = acr.FirstName,
            LastName = acr.LastName,
            Email = acr.Email,
            Telephone = acr.Telephone,
            Pesel = acr.Pesel,
            //IdTrip = acr.IdTrip,
            TripName = acr.TripName,
            PaymentDate = acr.PaymentDate
        };

        var clientExists = await dbContext.Clients.AnyAsync(c => c.Pesel == clientToTrip.Pesel);
        if (!clientExists)
        {
            var newClient = new Client()
            {
                IdClient = clientToTrip.IdClient,
                FirstName = clientToTrip.FirstName,
                LastName = clientToTrip.LastName,
                Email = clientToTrip.Email,
                Telephone = clientToTrip.Telephone,
                Pesel = clientToTrip.Pesel
            };
            await dbContext.Clients.AddAsync(newClient);
        }

        var clientIsAssigned = await dbContext.ClientTrips.AnyAsync(c =>
            c.IdClient == clientToTrip.IdClient && c.IdTrip == idTrip);
        if (clientIsAssigned)
        {
            return BadRequest("Client is already assigned to this trip");
        }

        var tripExists =
            await dbContext.Trips.AnyAsync(t => t.IdTrip == idTrip && t.Name == clientToTrip.TripName);
        if (!tripExists)
        {
            return BadRequest("Trip with given id and name does not exist");
        }

        var clientTrip = new ClientTrip()
        {
            IdClient = clientToTrip.IdClient,
            IdTrip = idTrip,
            RegisteredAt = DateTime.Now,
            PaymentDate = null,
        };
        var addClientTrip = await dbContext.ClientTrips.AddAsync(clientTrip);
        
        await dbContext.SaveChangesAsync();
        
        return Ok();
    }
    
    
}