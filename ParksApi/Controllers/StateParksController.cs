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
  public class StateParksController : ControllerBase
  {
    private ParksApiContext _db;

    public StateParksController(ParksApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<StatePark>> Get(string name, string state, string city, string description)
    {
      var query = _db.StateParks.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.StateParkName == name);
      }
      if (state != null)
      {
        query = query.Where(entry => entry.StateParkState == state);
      }
      if (city != null)
      {
        query = query.Where(entry => entry.StateParkCity == city);
      }
      if (description != null)
      {
        query = query.Where(entry => entry.StateParkDescription == description);
      }
      return query.ToList();
    }

    [HttpPost]
    public void Post([FromBody] StatePark statePark)
    {
      _db.StateParks.Add(statePark);
      _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult<StatePark> GetAction(int id)
    {
      return _db.StateParks.FirstOrDefault(entry => entry.StateParkId == id);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] StatePark statePark)
    {
      statePark.StateParkId = id;
      _db.Entry(statePark).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var stateParkToDelete = _db.StateParks.FirstOrDefault(entry => entry.StateParkId == id);
      _db.StateParks.Remove(stateParkToDelete);
      _db.SaveChanges();
    }
  }
}