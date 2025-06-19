using Microsoft.AspNetCore.Mvc;
using RoomService.Models;
using RoomService.Repositories;

namespace RoomService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository _repository;

        public RoomsController(IRoomRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var room = _repository.GetById(id);
            return room == null ? NotFound() : Ok(room);
        }

        [HttpPost]
        public IActionResult Create(Room room)
        {
            _repository.Add(room);
            return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
        }
    }
}
