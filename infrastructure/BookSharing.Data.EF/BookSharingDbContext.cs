using Microsoft.EntityFrameworkCore;

namespace BookSharing.Data.EF
{
    public class BookSharingDbContext : DbContext
    {
        public DbSet<AuthorDto> Authors { get; set; }
        public DbSet<BookDto> Books { get; set; }
        public DbSet<GenreDto> Genres { get; set; }
        public DbSet<PublisherDto> Publishers { get; set; }
        public DbSet<RentLocationAddressDto> RentLocationAddresses { get; set; }
        public DbSet<RentLocationDto> RentLocations { get; set; }
        public DbSet<UserDto> Users { get; set; }
        public DbSet<UserTypeDto> UserTypes { get; set; }

        public BookSharingDbContext(DbContextOptions<BookSharingDbContext> options) : base(options)
        {
        }
    }
}
