using BookAPI.Models;
using BookAPI_SecondWeek_Assignment.Repository;

namespace BookAPI_SecondWeek_Assignment.Services.Interfaces
{
    public interface IBookService
    {
        Book GetBookById(int id);
        List<Book> GetAllBooks();
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void PartialUpdateBook(int id, decimal price);
        void DeleteBook(int id);
    }
}
