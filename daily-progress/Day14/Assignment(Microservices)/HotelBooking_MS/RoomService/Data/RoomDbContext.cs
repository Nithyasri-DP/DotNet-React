using Microsoft.EntityFrameworkCore;
using RoomService.Models;
using System.Collections.Generic;

namespace RoomService.Data
{
    public class RoomDbContext : DbContext
    {
        public RoomDbContext(DbContextOptions<RoomDbContext> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
    }
}
