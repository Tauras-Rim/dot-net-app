using dot_net_example.Models;
using dot_net_example.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_example.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //GET: api/Books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return _bookService.GetBooks();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Book> PostCustomer([FromBody] Book book)
        {
            _bookService.PostBook(book);
            return Ok("Book created");
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(long id)
        {
            try
            {
                _bookService.DeleteBook(id);
                return Ok("Book with id " + id + " deleted");
            }
            catch (ArgumentException)
            {
                return NotFound("Book with id " + id + " not found");
            }
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutCustomer(long id, Book book)
        {
            try
            {
                _bookService.PutBook(id, book);
                return Ok("Book with id " + id + " updated");
            }
            catch (ArgumentException)
            {
                return NotFound("Book with id " + id + " not found");
            }
        }

        // //GET: api/Books/5
        [HttpGet("{id}")]
        public ActionResult<Book> GetCustomer(long id)
        {
            try
            {
                return _bookService.GetBook(id);
            }
            catch (ArgumentException)
            {
                return NotFound("Book with id " + id + " not found");
            }
        }
    }
}
