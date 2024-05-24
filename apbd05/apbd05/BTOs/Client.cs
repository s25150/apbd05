using System.ComponentModel.DataAnnotations;

namespace apbd05.BTOs;

public class Client
{
    [MaxLength(120)] public string FirstName { get; set; }
    [MaxLength(120)] public string LastName { get; set; }
    [MaxLength(120)] public string Email { get; set; }
    [MaxLength(120)] public int Telephone { get; set; }
    [MaxLength(120)] public int Pesel { get; set; }
    public int IdTrip { get; set; }
    public string TripName { get; set; }
    public DateTime PaymentDate { get; set; } //date
}