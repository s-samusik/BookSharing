using BookSharing.Models;
using Microsoft.EntityFrameworkCore;

namespace BookSharing.Data.EF
{
    public class BookSharingDbContext : DbContext
    {
        public DbSet<RentLocation> RentLocations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }

        public BookSharingDbContext(DbContextOptions<BookSharingDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildUserType(modelBuilder);
        }

        private void BuildUserType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserType>(action =>
            {
                action.HasIndex(dto => dto.Name).IsUnique();
            });
        }
    }
}
