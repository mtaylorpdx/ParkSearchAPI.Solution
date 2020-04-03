using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace ParksApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NationalParksController : ControllerBase
  {
    private ParksApiContext _db;

    public NationalParksController(ParksApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<NationalPark>> Get(string name, string state, string city, string description)
    {
      var query = _db.NationalParks.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.NationalParkName == name);
      }
      if (state != null)
      {
        query = query.Where(entry => entry.NationalParkState == state);
      }
      if (city != null)
      {
        query = query.Where(entry => entry.NationalParkCity == city);
      }
      if (description != null)
      {
        query = query.Where(entry => entry.NationalParkDescription == description);
      }
      return query.ToList();
    }

    [Authorize]
    [HttpPost]
    public void Post([FromBody] NationalPark nationalPark)
    {
      _db.NationalParks.Add(nationalPark);
      _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult<NationalPark> GetAction(int id)
    {
      return _db.NationalParks.FirstOrDefault(entry => entry.NationalParkId == id);
    }

    [Authorize]
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] NationalPark nationalPark)
    {
      nationalPark.NationalParkId = id;
      _db.Entry(nationalPark).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var nationalParkToDelete = _db.NationalParks.FirstOrDefault(entry => entry.NationalParkId == id);
      _db.NationalParks.Remove(nationalParkToDelete);
      _db.SaveChanges();
    }
  }
}