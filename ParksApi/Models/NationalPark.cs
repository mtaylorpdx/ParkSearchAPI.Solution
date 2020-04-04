using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParksApi.Models
{
  public class NationalPark
  {
    public NationalPark()
    {

    }

    public int NationalParkId { get; set; }
    [Required]
    public string NationalParkName { get; set; }
    [Required]
    public string NationalParkState { get; set; }
    [Required]
    public string NationalParkCity { get; set; }
    public string NationalParkDescription { get; set; }
  }
}
