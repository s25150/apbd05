using apbd05.Context;
using apbd05.Models;
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
    
    /*[HttpGet("{id:int}")]
    public IActionResult GetStudent(int id)
    {
        var student = _students.FirstOrDefault(st => st.IdStudent == id);
        if (student == null)
        {
            return NotFound($"Student with id {id} was not found");
        }
        
        return Ok(student);
    }
    
    [HttpPost]
    public IActionResult CreateStudent(Student student)
    {
        _students.Add(student);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateStudent(int id, Student student)
    {
        var studentToEdit= _students.FirstOrDefault(s => s.IdStudent == id);

        if (studentToEdit == null)
        {
            return NotFound($"Student with id {id} was not found");
        }
        
        _students.Remove(studentToEdit);
        _students.Add(student);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteStudent(int id)
    {
        var studentToEdit= _students.FirstOrDefault(s => s.IdStudent == id);
        if (studentToEdit == null)
        {
            return NoContent();
        }

        _students.Remove(studentToEdit);
        return NoContent();
    }*/
}