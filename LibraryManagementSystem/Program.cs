using System;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald");
            Book book2 = new Book("To Kill a Mockingbird", "Harper Lee");

            library.AddBook(book1);
            library.AddBook(book2);

            library.DisplayBooks();

            Console.WriteLine("\nBorrowing a book:");
            library.BorrowBook("The Great Gatsby");

            Console.WriteLine("\nUpdated library:");
            library.DisplayBooks();
        }
    }
}
