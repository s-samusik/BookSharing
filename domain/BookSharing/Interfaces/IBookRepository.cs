using BookSharing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSharing.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<List<Book>> GetAllByRequestAsync(string request);
        Task<List<Genre>> GetAllBookGenresAsync();
        Task<Genre> GetBookGenreByRequestAsync(string request);
        Task<List<Book>> GetAllByGenreAsync(Genre genre);
    }
}
