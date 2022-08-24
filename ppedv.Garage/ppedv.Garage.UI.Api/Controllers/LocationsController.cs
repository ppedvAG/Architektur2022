using Microsoft.AspNetCore.Mvc;
using ppedv.Garage.Model;
using ppedv.Garage.Model.Contracts.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.Garage.UI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public LocationsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/<LocationsController>
        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return _uow.LocationRepository.Query().ToList();
        }

        // GET api/<LocationsController>/5
        [HttpGet("{id}")]
        public Location Get(int id)
        {
            return _uow.LocationRepository.GetById(id);
        }

        // POST api/<LocationsController>
        [HttpPost]
        public void Post([FromBody] Location loc)
        {
            _uow.LocationRepository.Add(loc);
            _uow.SaveAll();
        }

        // PUT api/<LocationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Location loc)
        {
            _uow.LocationRepository.Update(loc);
            _uow.SaveAll();
        }

        // DELETE api/<LocationsController>/5
        [HttpDelete("{id}")]
        public void Delete(Location loc)
        {
            _uow.LocationRepository.Delete(loc);
            _uow.SaveAll();
        }
    }
}
