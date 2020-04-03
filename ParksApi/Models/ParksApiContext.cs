using Microsoft.EntityFrameworkCore;

namespace ParksApi.Models
{
  public class ParksApiContext : DbContext
  {
    public ParksApiContext(DbContextOptions<ParksApiContext> options)
      :base(options)
      {

      }

    public DbSet<StatePark> NationalParks { get; set; }
    public DbSet<StatePark> StateParks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<NationalPark>()
        .HasData(
          new NationalPark { NationalParkId = 1, NationalParkName = "National 1", NationalParkState = "NatState 1", NationalParkCity = "NatCity 1", NationalParkDescription ="NatDesc 1"},
          new NationalPark { NationalParkId = 2, NationalParkName = "National 2", NationalParkState = "NatState 2", NationalParkCity = "NatCity 2", NationalParkDescription ="NatDesc 2"},
          new NationalPark { NationalParkId = 3, NationalParkName = "National 3", NationalParkState = "NatState 3", NationalParkCity = "NatCity 3", NationalParkDescription ="NatDesc 3"},
          new NationalPark { NationalParkId = 4, NationalParkName = "National 4", NationalParkState = "NatState 4", NationalParkCity = "NatCity 4", NationalParkDescription ="NatDesc 4"},
          new NationalPark { NationalParkId = 5, NationalParkName = "National 5", NationalParkState = "NatState 5", NationalParkCity = "NatCity 5", NationalParkDescription ="NatDesc 5"}
        );
      builder.Entity<StatePark>()
        .HasData(
          new StatePark { StateParkId = 1, StateParkName = "State 1", StateParkState = "StateState 1", StateParkCity = "StateCity 1", StateParkDescription ="State Description 1"},
          new StatePark { StateParkId = 2, StateParkName = "State 2", StateParkState = "StateState 2", StateParkCity = "StateCity 2", StateParkDescription ="State Description 2"},
          new StatePark { StateParkId = 3, StateParkName = "State 3", StateParkState = "StateState 3", StateParkCity = "StateCity 3", StateParkDescription ="State Description 3"},
          new StatePark { StateParkId = 4, StateParkName = "State 4", StateParkState = "StateState 4", StateParkCity = "StateCity 4", StateParkDescription ="State Description 4"},
          new StatePark { StateParkId = 5, StateParkName = "State 5", StateParkState = "StateState 5", StateParkCity = "StateCity 5", StateParkDescription ="State Description 5"}
        );
    }
  }
}
