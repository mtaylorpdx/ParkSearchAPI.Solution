using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParksApi.Models
{
  public class NationalPark
  {
    public NationalPark()
    {
      this.StateParks = new HashSet<StatePark>();
    }

    public int NationalParkId { get; set; }
    // [Required]
    public string NationalParkName { get; set; }
    // [Required]
    public string NationalParkState { get; set; }
    // [Required]
    public string NationalParkCity { get; set; }
    public string NationalParkDescription { get; set; }
    
    public virtual ICollection<StatePark> StateParks { get; set; }
  }
}
