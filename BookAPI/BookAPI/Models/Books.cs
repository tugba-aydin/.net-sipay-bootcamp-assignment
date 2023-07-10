namespace BookAPI.Models
{
    public static class Books
    {
        public static List<Book> BookList { get; set; }

        static Books()
        {
           BookList = new List<Book>()
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
        
    }
}
