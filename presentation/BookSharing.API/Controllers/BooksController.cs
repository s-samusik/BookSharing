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
    [Authorize(Roles = "Administrator, Librarian")]
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
        /// <param name="bookDto"></param>
        /// <returns></returns>
        // POST: api/books/
        [HttpPost("")]
        public async Task<IActionResult> CreateBookAsync([FromForm] CreateBookDto bookDto)
        {
            if (bookDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = mapper.Map<Book>(bookDto);
            await bookRepository.AddAsync(book);
            var bookReadDto = mapper.Map<ReadBookDto>(book);

            return CreatedAtAction(nameof(GetBookByIdAsync), new { id = bookReadDto.Id }, bookReadDto);
        }

        /// <summary>
        /// Change existing book from database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookDto"></param>
        /// <returns></returns>
        // PUT: api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookAsync(int id, [FromForm] UpdateBookDto bookDto)
        {
            var book = await bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound(id);
            }

            mapper.Map(bookDto, book);

            await bookRepository.UpdateAsync(book);

            return NoContent();
        }

        /// <summary>
        /// Remove existing book from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound(id);
            }

            await bookRepository.DeleteAsync(book);

            return NoContent();
        }

        /// <summary>
        /// Return book from database with the specified id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            
            if (book == null)
            {
                return NotFound(id);
            }

            var bookReadDto = mapper.Map<ReadBookDto>(book);

            return Ok(bookReadDto);
        }

        /// <summary>
        /// Return all books that match the request.
        /// </summary>
        /// <param name="request">title of book or author or publisher.</param>
        /// <returns></returns>
        //GET: api/books/search/"title or author or publisher"
        [HttpGet("search/{request}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ReadBookDto>>> GetAllBooksByRequestAsync(string request)
        {
            var books = await bookRepository.GetAllByRequestAsync(request);
            var booksReadDto = mapper.Map<IEnumerable<ReadBookDto>>(books);

            return Ok(booksReadDto);
        }

        /// <summary>
        /// Return all book genres from database.
        /// </summary>
        /// <returns></returns>
        //GET: api/books/genres/
        [HttpGet("genres")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ReadGenreDto>>> GetAllBookGenresAsync()
        {
            var genres = await bookRepository.GetAllBookGenresAsync();
            var genresReadDto = mapper.Map<IEnumerable<ReadGenreDto>>(genres);

            return Ok(genresReadDto);
        }

        /// <summary>
        /// Return all books of concrete book genre.
        /// </summary>
        /// <param name="bookGenre"></param>
        /// <returns></returns>
        //GET: api/books/by_genre/"book genre"
        [HttpGet("by_genre/{bookGenre}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ReadBookDto>>> GetAllBooksByGenreAsync(string bookGenre)
        {
            var genre = await bookRepository.GetBookGenreByRequestAsync(bookGenre);
            if (genre == null)
            {
                return NotFound(bookGenre);
            }

            var books = await bookRepository.GetAllByGenreAsync(genre);
            var booksReadDto = mapper.Map<IEnumerable<ReadBookDto>>(books);

            return Ok(booksReadDto);
        }

        /// <summary>
        /// Count books from database.
        /// </summary>
        /// <returns></returns>
        //GET: api/books/count
        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<IActionResult> CountBooksAsync()
        {
            var count = await bookRepository.CountAsync();

            return Ok(count);
        }
    }
}
