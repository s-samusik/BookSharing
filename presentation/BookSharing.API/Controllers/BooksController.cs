using AutoMapper;
using BookSharing.Data;
using BookSharing.Interfaces;
using BookSharing.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSharing.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        // POST: api/books/
        [HttpPost("")]
        public async Task<ActionResult<BookDto>> CreateBookAsync(BookDto book)
        {
            if (book == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var bookResult = mapper.Map<Book>(book);

            await bookRepository.AddAsync(bookResult);

            return CreatedAtAction("GetBookByIdAsync", new { id = book.Id }, book);
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookAsync(int id, BookDto book)
        {
            if (id != book.Id) return BadRequest();

            var bookResult = mapper.Map<Book>(book);

            await bookRepository.UpdateAsync(bookResult);

            return Ok();
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookDto>> DeleteBookAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);

            if (book == null || book.Id != id) return NotFound();

            await bookRepository.DeleteAsync(book);

            return NoContent();
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookByIdAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book == null) return NotFound();

            var bookResult = mapper.Map<BookDto>(book);

            return Ok(bookResult);
        }

        //GET: api/books/search/"title or author or publisher"
        [HttpGet("search/{query}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooksByQueryAsync(string query)
        {
            var books = await bookRepository.GetAllByQueryAsync(query);
            var booksResult = mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(booksResult);
        }

        //GET: api/books/genres/
        [HttpGet("genres")]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetAllBookGenresAsync()
        {
            var genres = await bookRepository.GetAllBookGenresAsync();
            var genresResult = mapper.Map<IEnumerable<GenreDto>>(genres);

            return Ok(genresResult);
        }

        //GET: api/books/by_genre/"book genre"
        [HttpGet("by_genre/{bookGenre}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooksByGenreAsync(string bookGenre)
        {
            var genre = await bookRepository.GetBookGenreByQueryAsync(bookGenre);
            if (genre == null) return NotFound(genre);

            var books = await bookRepository.GetAllByGenreAsync(genre);
            var booksResult = mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(booksResult);
        }
    }
}
