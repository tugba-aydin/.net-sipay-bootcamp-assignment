using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.GetById;
using BookStore.BookOperations.UpdateBook;
using BookStore.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext context;
        public BookController(BookStoreDbContext _context) { 
            context = _context;
        }

        [HttpGet]
        public IActionResult GetBooks() {
            GetBooksQuery query = new GetBooksQuery(context);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetByIdQuery query = new GetByIdQuery(context);
            query.Id = id;
            var result=query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook) 
        {
            CreateBookCommand command = new CreateBookCommand(context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBook([FromBody] UpdateBookModel updateBook,int id)
        {
            UpdateBookCommand command = new UpdateBookCommand(context);
            try
            {
                command.Model = updateBook;
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = context.Books.Where(b => b.Id == id).FirstOrDefault();
            if (book == null) return BadRequest();
            context.Books.Remove(book);
            context.SaveChanges();
            return Ok();
        }
    }
}
