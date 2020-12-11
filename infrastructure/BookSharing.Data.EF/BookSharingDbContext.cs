using BookSharing.Models;
using Microsoft.EntityFrameworkCore;

namespace BookSharing.Data.EF
{
    public class BookSharingDbContext : DbContext
    {
        public DbSet<RentLocation> RentLocations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }


        public BookSharingDbContext(DbContextOptions<BookSharingDbContext> options) : base(options)
        {
        }
    }
}
