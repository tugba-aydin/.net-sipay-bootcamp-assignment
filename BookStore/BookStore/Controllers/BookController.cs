using AutoMapper;
using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.DeleteBook;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.GetById;
using BookStore.BookOperations.UpdateBook;
using BookStore.DbOperations;
using FluentValidation;
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
        private readonly IMapper mapper;
        public BookController(BookStoreDbContext _context, IMapper _mapper) { 
            context = _context;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult GetBooks() {
            GetBooksQuery query = new GetBooksQuery(context, mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetByIdQuery query = new GetByIdQuery(context,mapper);
            query.Id = id;
            GetByIdQueryValidator validator = new GetByIdQueryValidator();
            validator.ValidateAndThrow(query);
            var result=query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook) 
        {
            CreateBookCommand command = new CreateBookCommand(context,mapper);
            try
            {
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
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
                UpdateBookCommandValidator validator= new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
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
            DeleteBookCommand command = new DeleteBookCommand(context);
            try
            {
                command.Id = id;
                DeleteCommandValidator validator = new DeleteCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
