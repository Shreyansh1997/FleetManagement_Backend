using FleetManagement_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement_Backend.DAL
{
    public interface IBillingInterface
    {


        Task<ActionResult<Billing>?> GetBillingByBookingId(int Id);

        Task<ActionResult<Billing>?> GetBillingById(int billingid);

        Task<ActionResult<Billing>?> SaveBilling(Billing billing);



    }
}
