using Microsoft.EntityFrameworkCore;

namespace RoomService.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string? RoomNumber { get; set; }
        public string? Type { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
