using FleetManagement_Backend.DAL;
using FleetManagement_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IBookingInterface booking;

        public BookingController(IBookingInterface booking)
        {
            this.booking = booking;
        }

        [HttpGet("byBookingId/{id}")]
        public async Task<ActionResult<Booking>> GetBookingById(int id) 
        {
            var booking_list = await booking.GetBookingById(id);

            return booking == null ? NotFound() : booking_list;
        }

        [HttpGet("by-phone/{mobileno}")]

        public async Task<ActionResult<Booking>> GetBookingByPhoneNo(string mobileno) 
        {
            var booking_list = await booking.GetBookingByPhoneNo(mobileno);

            return booking_list == null ? NotFound() : booking_list;
        }

        [HttpGet("by-email/{email}")]
        public async Task<ActionResult<Booking>> GetBookingByEmail(string email)
        {
            var booking_list = await booking.GetBookingByEmail(email);
            return booking_list == null ? NotFound() : booking_list;
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking_post) 
        {
            await booking.SaveInBooking(booking_post);

            return CreatedAtAction("GetBookingById", new { id = booking_post.BookingId }, booking_post);
        }

    }
}
