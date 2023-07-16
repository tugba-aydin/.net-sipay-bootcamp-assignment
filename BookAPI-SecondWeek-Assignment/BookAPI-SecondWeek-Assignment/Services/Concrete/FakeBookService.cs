using BookAPI.Models;
using BookAPI_SecondWeek_Assignment.Services.Abstract;
using BookAPI_SecondWeek_Assignment.Services.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookAPI_SecondWeek_Assignment.Services.Concrete
{
    public class FakeBookService : IFakeBookService
    {
        //A fake service was created as requested in the assignment.
        private List<Book> books {  get; set; }
        public FakeBookService() {
            books = new List<Book>()
            {
               new Book{ Id = 1,
                Name = "Sefiller",
                Author = "Victor Hugo",
                Category = "X",
                Price = 100 },
               new Book{ Id = 2,
                Name = "Kürk Mantolu Madonna",
                Author = "Sabahattin Ali",
                Category = "X",
                Price = 150 },
        };
        }
        public void CreateBook(Book book)
        {
            books.Add(book);
        }

        public void DeleteBook(int id)
        {
            var deleteBook = books.Where(b => b.Id == id).FirstOrDefault();
            books.Remove(deleteBook);
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            var book = books.Where(b => b.Id == id).FirstOrDefault();
            return book;
        }

        public void PartialUpdateBook(int id, decimal price)
        {
            var updateBook = books.Where(b => b.Id == id).FirstOrDefault();
            updateBook.Price = price;
        }

        public void UpdateBook(Book book)
        {
            var updateBook = books.Where(b => b.Id == book.Id).FirstOrDefault();
            updateBook.Name = book.Name;
            updateBook.Author = book.Author;
            updateBook.Category = book.Category;
            updateBook.Price = book.Price;
        }
    }
}
