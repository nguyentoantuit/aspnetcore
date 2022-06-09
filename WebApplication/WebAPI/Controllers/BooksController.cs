using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Database;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
           var books =  await _bookService.GetBooksAsync();
           return Ok(books);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            await _bookService.CreateBookAsync(book);
            return NoContent();
        }
        
        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateBook(int bookId, [FromBody] Book book)
        {
            await _bookService.UpdateBookAsync(bookId, book);
            return NoContent();
        }
        
        [HttpDelete("{bookId}")]
        public async Task<IActionResult> UpdateBook(int bookId)
        {
            await _bookService.DeleteBookAsync(bookId);
            return NoContent();
        }
    }
}