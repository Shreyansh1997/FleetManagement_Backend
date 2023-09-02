using FleetManagement_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement_Backend.DAL
{
    public interface IAirportInterface
    {
        Task<ActionResult<IEnumerable<Airport>>> GetAllAirport();

        Task<ActionResult<Airport>?> GetAirport(int Id);
    }
}
