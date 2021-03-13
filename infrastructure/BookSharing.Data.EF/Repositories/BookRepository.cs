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

            var bookGenre = await context.Genres
                                      .Where(x => x.Name == book.Genre.Name)
                                      .FirstOrDefaultAsync();
            if (bookGenre == null)
            {
                Genre genre = new Genre
                {
                    Name = book.Genre.Name
                };

                await context.Genres.AddAsync(genre);
                await context.SaveChangesAsync();

                bookGenre = genre;
            }
            book.Genre = bookGenre;


            var bookAuthor = await context.Authors
                                      .Where(x => x.Name == book.Author.Name)
                                      .FirstOrDefaultAsync();
            if (bookAuthor == null)
            {
                Author author = new Author
                {
                    Name = book.Author.Name
                };

                await context.Authors.AddAsync(author);
                await context.SaveChangesAsync();

                bookAuthor = author;
            }
            book.Author = bookAuthor;


            var bookPublisher = await context.Publishers
                                             .Where(x => x.Name == book.Publisher.Name)
                                             .FirstOrDefaultAsync();
            if (bookPublisher == null)
            {
                Publisher publisher = new Publisher
                {
                    Name = book.Publisher.Name
                };

                await context.Publishers.AddAsync(publisher);
                await context.SaveChangesAsync();

                bookPublisher = publisher;
            }
            book.Publisher = bookPublisher;

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            var context = dbContextFactory.Create(typeof(BookRepository));

            context.Entry(book).State = EntityState.Modified;

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
                                    .Include(x => x.Genre)
                                    .Include(x => x.Author)
                                    .Include(x => x.Publisher)
                                    .Where(x => x.Id == id)
                                    .FirstOrDefaultAsync();
            return book;
        }

        public async Task<List<Book>> GetAllByRequestAsync(string query)
        {
            var context = dbContextFactory.Create(typeof(BookRepository));

            var books = await context.Books
                                     .Include(x => x.Genre)
                                     .Include(x => x.Author)
                                     .Include(x => x.Publisher)
                                     .Where(x => x.Title.Contains(query)
                                              || x.Author.Name.Contains(query)
                                              || x.Publisher.Name.Contains(query))
                                     .ToListAsync();
            return books;
        }

        public async Task<List<Genre>> GetAllBookGenresAsync()
        {
            var context = dbContextFactory.Create(typeof(BookRepository));
            var genres = await context.Genres.ToListAsync();

            return genres;
        }

        public async Task<Genre> GetBookGenreByRequestAsync(string query)
        {
            var context = dbContextFactory.Create(typeof(BookRepository));
            var genre = await context.Genres
                                     .Where(x => x.Name.Contains(query))
                                     .FirstOrDefaultAsync();
            return genre;
        }

        public async Task<List<Book>> GetAllByGenreAsync(Genre genre)
        {
            var context = dbContextFactory.Create(typeof(BookRepository));

            var books = await context.Books
                                     .Include(x => x.Genre)
                                     .Include(x => x.Author)
                                     .Include(x => x.Publisher)
                                     .Where(x => x.Genre.Id == genre.Id)
                                     .ToListAsync();
            return books;
        }

        public async Task<int> CountAsync()
        {
            var context = dbContextFactory.Create(typeof(BookRepository));

            var count = await context.Books.CountAsync();

            return count;
        }

        public async Task<List<Book>> GetPopularBooksAsync(int number)
        {
            var context = dbContextFactory.Create(typeof(BookRepository));

            var count = await context.Books.CountAsync();

            if (number > count)
            {
                number = count;
            }

            var books = await context.Books
                                     .Include(x => x.Genre)
                                     .Include(x => x.Author)
                                     .Include(x => x.Publisher)
                                     .Take(number)
                                     .ToListAsync();
            return books;
        }
    }
}
