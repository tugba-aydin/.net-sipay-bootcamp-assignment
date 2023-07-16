using BookAPI.Models;
using BookAPI_SecondWeek_Assignment.Data;
using BookAPI_SecondWeek_Assignment.Repository;
using BookAPI_SecondWeek_Assignment.Services.Interfaces;

namespace BookAPI_SecondWeek_Assignment.Services.Concrete
{
    public class BookService:IBookService
    {
        //The service where the necessary transactions are made over the Repository for the book asset

        private readonly IRepository<Book> repository;
        public BookService(IRepository<Book> _repository) {
            repository = _repository;
        }

        public void CreateBook(Book book)
        {
            repository.Create(book);
        }

        public void DeleteBook(int id)
        {
            repository.Delete(id);
        }

        public List<Book> GetAllBooks()
        {
            return repository.GetAll();
        }

        public Book GetBookById(int id)
        {
            return repository.GetById(id);
        }

        public void PartialUpdateBook(int id, decimal price)
        {
            Book book = GetBookById(id);
            book.Price = price;
            UpdateBook(book);
        }

        public void UpdateBook(Book book)
        {
            repository.Update(book);
        }
    }
}
