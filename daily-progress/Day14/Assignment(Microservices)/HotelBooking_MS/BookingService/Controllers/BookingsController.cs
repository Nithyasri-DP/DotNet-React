using Microsoft.AspNetCore.Mvc;
using BookingService.Models;
using BookingService.Repositories;

namespace BookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _repository;

        public BookingsController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var booking = _repository.GetById(id);
            return booking == null ? NotFound() : Ok(booking);
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            _repository.Add(booking);
            return CreatedAtAction(nameof(GetById), new { id = booking.Id }, booking);
        }
    }
}
