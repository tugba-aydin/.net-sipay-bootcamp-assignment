using BookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = Books.BookList;
            if (books == null) return StatusCode(404, "No Records Found");
            return StatusCode(200, books);

        }
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            if (id.GetType() != typeof(int)) return StatusCode(400, "Id type is wrong");
            if (id == 0) return StatusCode(404, "No Records Found");
            var book = Books.BookList.Where(b=> b.Id == id).FirstOrDefault();
            if(book == null) return NotFound();
            return StatusCode(200, book);
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (book == null) return StatusCode(400, "Book is null");
            Books.BookList.Add(book);
            return StatusCode(201, "Added new book");
        }
        [HttpPut]
        public IActionResult UpdateBook(Book book) { 
            if( book == null) return StatusCode(400, "Book is null");
            var updateBook = Books.BookList.Where(b=>b.Id==book.Id).FirstOrDefault();
            if(updateBook == null) return StatusCode(404, "No Records Found");
            updateBook.Name = book.Name;
            updateBook.Author = book.Author;
            updateBook.Category = book.Category;
            updateBook.Price = book.Price;
            return StatusCode(201, "Updated book");
        }
        [HttpPatch]
        public IActionResult PartialUpdate(int id, decimal price)
        {
            if (id.GetType() != typeof(int) && price.GetType()!=typeof(decimal) && id==0) return BadRequest();
            var updateBook = Books.BookList.Where(b => b.Id == id).FirstOrDefault();
            if (updateBook == null) return StatusCode(404, "No Records Found");
            updateBook.Price = price;
            return StatusCode(201, "Updated book price");
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var deleteBook=Books.BookList.Where(b=>b.Id==id).FirstOrDefault();
            if (deleteBook == null) return StatusCode(404, "No Records Found");
            Books.BookList.Remove(deleteBook);
            return StatusCode(201, "Deleted book");
        }
    }
}
