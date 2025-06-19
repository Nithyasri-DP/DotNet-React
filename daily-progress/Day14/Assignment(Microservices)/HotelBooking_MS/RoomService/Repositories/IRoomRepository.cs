using RoomService.Models;

namespace RoomService.Repositories
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
        Room? GetById(int id);
        void Add(Room room);
    }
}
