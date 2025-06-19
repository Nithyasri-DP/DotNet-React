using BookingService.Models;

namespace BookingService.Repositories
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAll();
        Booking? GetById(int id);
        void Add(Booking booking);
    }
}
