using Microsoft.AspNetCore.Mvc;

namespace apbd05.RequestModels;

public class AssignClientRequest
{
    public int IdClient { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Pesel { get; set; } = null!;
    
    //public int IdTrip { get; set; }

    public string TripName { get; set; } = null!; //pole Name w Trip
    
    public DateTime? PaymentDate { get; set; }
}