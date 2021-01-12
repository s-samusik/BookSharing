using BookSharing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSharing.Interfaces
{
    public interface IBookRepository
    {
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);

        Task<Book> GetByIdAsync(int id);
        Task<List<Book>> GetAllByRequestAsync(string request);
        Task<List<Genre>> GetAllBookGenresAsync();
        Task<Genre> GetBookGenreByRequestAsync(string request);
        Task<List<Book>> GetAllByGenreAsync(Genre genre);
    }
}
