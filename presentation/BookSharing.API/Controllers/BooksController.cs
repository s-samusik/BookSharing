using AutoMapper;
using BookSharing.Data;
using BookSharing.Interfaces;
using BookSharing.Models;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Add new book to database.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        // POST: api/books/
        [HttpPost("")]
        [Authorize]
        public async Task<ActionResult<BookDto>> CreateBookAsync(BookDto book)
        {
            if (book == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var bookResult = mapper.Map<Book>(book);

            await bookRepository.AddAsync(bookResult);

            return CreatedAtAction("GetBookByIdAsync", new { id = book.Id }, book);
        }

        /// <summary>
        /// Change existing book from database.
        /// </summary>
        /// <param name="id">existing book</param>
        /// <param name="book"></param>
        /// <returns></returns>
        // PUT: api/books/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutBookAsync(int id, BookDto book)
        {
            if (id != book.Id) return BadRequest();

            var bookResult = mapper.Map<Book>(book);

            await bookRepository.UpdateAsync(bookResult);

            return Ok();
        }

        /// <summary>
        /// Remove existing book from database.
        /// </summary>
        /// <param name="id">existing book.</param>
        /// <returns></returns>
        // DELETE: api/books/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<BookDto>> DeleteBookAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);

            if (book == null || book.Id != id) return NotFound();

            await bookRepository.DeleteAsync(book);

            return NoContent();
        }

        /// <summary>
        /// Return book from database with the specified id.
        /// </summary>
        /// <param name="id">existing book.</param>
        /// <returns></returns>
        // GET: api/books/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<BookDto>> GetBookByIdAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book == null) return NotFound();

            var bookResult = mapper.Map<BookDto>(book);

            return Ok(bookResult);
        }

        /// <summary>
        /// Return all books that match the request.
        /// </summary>
        /// <param name="request">title of book or author or publisher.</param>
        /// <returns></returns>
        //GET: api/books/search/"title or author or publisher"
        [HttpGet("search/{request}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooksByRequestAsync(string request)
        {
            var books = await bookRepository.GetAllByRequestAsync(request);
            var booksResult = mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(booksResult);
        }

        /// <summary>
        /// Return all book genres from database.
        /// </summary>
        /// <returns></returns>
        //GET: api/books/genres/
        [HttpGet("genres")]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetAllBookGenresAsync()
        {
            var genres = await bookRepository.GetAllBookGenresAsync();
            var genresResult = mapper.Map<IEnumerable<GenreDto>>(genres);

            return Ok(genresResult);
        }

        /// <summary>
        /// Return all books of concrete book genre.
        /// </summary>
        /// <param name="bookGenre">genre of book</param>
        /// <returns></returns>
        //GET: api/books/by_genre/"book genre"
        [HttpGet("by_genre/{bookGenre}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooksByGenreAsync(string bookGenre)
        {
            var genre = await bookRepository.GetBookGenreByRequestAsync(bookGenre);
            if (genre == null) return NotFound(genre);

            var books = await bookRepository.GetAllByGenreAsync(genre);
            var booksResult = mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(booksResult);
        }
    }
}
