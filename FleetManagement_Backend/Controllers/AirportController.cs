using FleetManagement_Backend.DAL;
using FleetManagement_Backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class AirportController : ControllerBase
    {
        private readonly IAirportInterface airportInterface;

        public AirportController(IAirportInterface airportinterface)
        {
            airportInterface = airportinterface;
        }

        // GET: api/<AirportController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airport>>?> GetAirport()
        {
            if (await airportInterface.GetAllAirport() == null)
            {
                return NotFound();
            }

            return await airportInterface.GetAllAirport();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Airport>> GetAirportById(int id)
        {
            var airport = await airportInterface.GetAirport(id);

            return airport == null ? NotFound() : airport;
        }
    }
}
