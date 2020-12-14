using BookSharing.Interfaces;
using BookSharing.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSharing.Data.EF.Repositories
{
    class BookRepository : IBookRepository
    {
        private readonly DbContextFactory dbContextFactory;
        public BookRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task AddAsync(Book book)
        {
            var context = dbContextFactory.Create(typeof(BookRepository));
            var genre = await context.Genres
                                     .AsNoTracking()
                                     .Where(x => x.Id == book.Genre.Id)
                                     .FirstOrDefaultAsync();
            if (genre == null) genre = book.Genre;

            var author = await context.Authors
                                      .AsNoTracking()
                                      .Where(x => x.Id == book.Author.Id)
                                      .FirstOrDefaultAsync();
            if (author == null) author = book.Author;

            var publisher = await context.Publishers
                                         .AsNoTracking()
                                         .Where(x => x.Id == book.Publisher.Id)
                                         .FirstOrDefaultAsync();
            if (publisher == null) publisher = book.Publisher;

            Book newBook = new Book
            {
                Title = book.Title,
                Description = book.Description,
                Genre = genre,
                Author = author,
                Publisher = publisher
            };

            await context.Books.AddAsync(newBook);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            var context = dbContextFactory.Create(typeof(BookRepository));

            context.Entry(book).State = EntityState.Modified;
            context.Entry(book.Genre).State = EntityState.Modified;
            context.Entry(book.Author).State = EntityState.Modified;
            context.Entry(book.Publisher).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            var context = dbContextFactory.Create(typeof(BookRepository));

            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var context = dbContextFactory.Create(typeof(BookRepository));

            var book = await context.Books
                                    .AsNoTracking()
                                    .Include(x => x.Genre)
                                    .Include(x => x.Author)
                                    .Include(x => x.Publisher)
                                    .Where(x => x.Id == id)
                                    .FirstOrDefaultAsync();
            return book;
        }

        public async Task<List<Book>> GetAllByQueryAsync(string query)
        {
            var context = dbContextFactory.Create(typeof(BookRepository));

            var books = await context.Books
                                     .AsNoTracking()
                                     .Include(x => x.Genre)
                                     .Include(x => x.Author)
                                     .Include(x => x.Publisher)
                                     .Where(x => x.Title.Contains(query) 
                                              || x.Author.Name.Contains(query) 
                                              || x.Publisher.Name.Contains(query))
                                     .ToListAsync();
            return books;
        }

        public async Task<List<Genre>> GetAllBookGenres()
        {
            var context = dbContextFactory.Create(typeof(BookRepository));
            var genres = await context.Genres.ToListAsync();

            return genres;
        }

        public async Task<Genre> GetBookGenreByQueryAsync(string query)
        {
            var context = dbContextFactory.Create(typeof(BookRepository));
            var genre = await context.Genres
                                     .AsNoTracking()
                                     .Where(x => x.Name.Contains(query))
                                     .FirstOrDefaultAsync();
            return genre;
        }

        public async Task<List<Book>> GetAllByGenreAsync(Genre genre)
        {
            var context = dbContextFactory.Create(typeof(BookRepository));

            var books = await context.Books
                                     .AsNoTracking()
                                     .Include(x => x.Genre)
                                     .Include(x => x.Author)
                                     .Include(x => x.Publisher)
                                     .Where(x => x.Genre.Id == genre.Id)
                                     .ToListAsync();
            return books;
        }
    }
}
