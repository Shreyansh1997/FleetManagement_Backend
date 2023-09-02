using FleetManagement_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement_Backend.DAL
{
    public interface ICarCategoryInterface
    {
        Task<ActionResult<IEnumerable<CarCategory>>?> GetAllCarCategories();
    }
}
