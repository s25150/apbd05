using System.ComponentModel.DataAnnotations;

namespace apbd05.BTOs;

public class Trip
{
    [MaxLength(120)] public string Name { get; set; }
    [MaxLength(220)] public string Description { get; set; }
    public DateTime DateFrom { get; set; }//date
    public DateTime DateTo { get; set; }//date
    public int MaxPeople { get; set; }
    public List<Country> Countries { get; set; }
    public List<Client> Clients { get; set; }
}