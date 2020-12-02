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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildAuthors(modelBuilder);
            BuildBooks(modelBuilder);
            BuildGenres(modelBuilder);
            BuildPublisher(modelBuilder);
            BuildRentLocationAddress(modelBuilder);
            BuildRentLocation(modelBuilder);
            BuildUser(modelBuilder);
            BuildUserType(modelBuilder);
        }

        private void BuildAuthors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorDto>(action =>
            {
                action.Property(dto => dto.Name)
                      .HasMaxLength(50)
                      .IsRequired();
            });
        }
        private void BuildBooks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDto>(action =>
            {
                action.Property(dto => dto.Title)
                      .HasMaxLength(50)
                      .IsRequired();

                action.HasOne(dto => dto.Author)
                      .WithMany(dto => dto.Books)
                      .IsRequired();

                action.HasOne(dto => dto.Genre)
                      .WithMany(dto => dto.Books)
                      .IsRequired();

                action.HasOne(dto => dto.Publisher)
                      .WithMany(dto => dto.Books)
                      .IsRequired();
            });
        }
        private void BuildGenres(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreDto>(action =>
            {
                action.Property(dto => dto.Name)
                      .HasMaxLength(50)
                      .IsRequired();
            });
        }
        private void BuildPublisher(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PublisherDto>(action =>
            {
                action.Property(dto => dto.Name)
                      .HasMaxLength(50)
                      .IsRequired();
            });
        }
        private void BuildRentLocationAddress(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentLocationAddressDto>(action =>
            {
                action.Property(dto => dto.Country)
                      .HasMaxLength(50);

                action.Property(dto => dto.City)
                      .HasMaxLength(50)
                      .IsRequired();

                action.Property(dto => dto.Street)
                      .HasMaxLength(50)
                      .IsRequired();

                action.Property(dto => dto.Building)
                      .HasMaxLength(10)
                      .IsRequired();

                action.HasOne(dto => dto.RentLocation)
                      .WithOne(dto => dto.RentLocationAddress)
                      .IsRequired();
            });
        }
        private void BuildRentLocation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentLocationDto>(action =>
            {
                action.Property(dto => dto.Name)
                      .HasMaxLength(50)
                      .IsRequired();
            });

        }
        private void BuildUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDto>(action =>
            {
                action.Property(dto => dto.Nickname)
                      .HasMaxLength(50)
                      .IsRequired();

                action.Property(dto => dto.Email)
                      .HasMaxLength(50)
                      .IsRequired();

                action.Property(dto => dto.PhoneNumber)
                      .HasMaxLength(50)
                      .IsRequired();

                action.Property(dto => dto.Password)
                      .HasMaxLength(50)
                      .IsRequired();

                action.HasOne(dto => dto.UserType)
                      .WithMany(dto => dto.Users)
                      .IsRequired();
            });

        }
        private void BuildUserType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTypeDto>(action =>
            {
                action.Property(dto => dto.Name)
                      .HasMaxLength(50)
                      .IsRequired();
            });
        }
    }
}
