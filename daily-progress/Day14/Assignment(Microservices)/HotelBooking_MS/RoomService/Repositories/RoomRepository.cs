using RoomService.Models;
using RoomService.Data;

namespace RoomService.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly RoomDbContext _context;

        public RoomRepository(RoomDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Room> GetAll() => _context.Rooms.ToList();

        public Room? GetById(int id) => _context.Rooms.FirstOrDefault(r => r.Id == id);

        public void Add(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }
    }
}
