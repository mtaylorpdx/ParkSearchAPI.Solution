using System.ComponentModel.DataAnnotations;

namespace ParksApi.Models
{
  public class StatePark
  {
    public int StateParkId { get; set; }
    [Required]
    public string StateParkName { get; set; }
    [Required]
    public string StateParkState { get; set; }
    [Required]
    public string StateParkCity { get; set; }
    public string StateParkDescription { get; set; }
    [Required]
    public int NationalParkId { get; set; } = 0;
  }
}
