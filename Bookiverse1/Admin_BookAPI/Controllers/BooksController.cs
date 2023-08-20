using Admin_BookAPI.Data;
using Admin_BookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly BookDbContext _context;

        public BooksController(BookDbContext context)

        {

            _context = context;
        }

        // GET: api/books

        [HttpGet]

        public ActionResult<IEnumerable<Books>> GetBooks()

        {

            return _context.Books.ToList();

        }

        // GET: api/books/{id}

        [HttpGet("{id}")]

        public ActionResult<Books> GetBook(int id)

        {

            var book = _context.Books.FirstOrDefault(b => b.BookId == id);

            if (book == null)

            {

                return NotFound();

            }

            return book;

        }

        // POST: api/books

        [HttpPost]
        public ActionResult<Books> CreateBook(Books book)

        {

            _context.Books.Add(book);

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);

        }

        // PUT: api/books/{id}

        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, Books updatedBook)

        {

            var book = _context.Books.FirstOrDefault(b => b.BookId == id);

            if (book == null)

            {

                return NotFound();

            }

            book.PublishedDate = updatedBook.PublishedDate;

            book.IsbnNo = updatedBook.IsbnNo;

            book.Author = updatedBook.Author;

            book.Title = updatedBook.Title;

            book.Description = updatedBook.Description;

            _context.SaveChanges();

            return NoContent();

        }

        // DELETE: api/books/{id}

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)

        {

            var book = _context.Books.FirstOrDefault(b => b.BookId == id);

            if (book == null)

            {

                return NotFound();

            }

            _context.Books.Remove(book);

            _context.SaveChanges();

            return NoContent();



        }
    }
}
