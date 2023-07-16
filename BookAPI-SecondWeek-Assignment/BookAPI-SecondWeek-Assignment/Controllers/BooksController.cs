using BookAPI.Models;
using BookAPI_SecondWeek_Assignment.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;
        public BooksController(IBookService _bookService)
        {
            bookService = _bookService;
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = bookService.GetAllBooks();
            if (books == null) return StatusCode(404, "No Records Found");
            return StatusCode(200, books);

        }
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            if (id.GetType() != typeof(int)) return StatusCode(400, "Id type is wrong");
            if (id == 0) return StatusCode(404, "No Records Found");
            var book = bookService.GetBookById(id);
            if (book == null) return NotFound();
            return StatusCode(200, book);
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (book == null) return StatusCode(400, "Book is null");
            bookService.CreateBook(book);
            return StatusCode(201, "Added new book");
        }
        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            if (book == null) return StatusCode(400, "Book is null");
            bookService.UpdateBook(book);
            return StatusCode(201, "Updated book");
        }
        [HttpPatch]
        public IActionResult PartialUpdateBook(int id, decimal price)
        {
            if (id.GetType() != typeof(int) && price.GetType() != typeof(decimal) && id == 0) return StatusCode(400, "Please check id and price");
            bookService.PartialUpdateBook(id,price);
            return StatusCode(201, "Updated book price");
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            if (id == 0) return BadRequest();
            bookService.DeleteBook(id);
            return StatusCode(201, "Deleted book");
        }
    }
}
