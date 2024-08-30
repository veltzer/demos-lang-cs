using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void DisplayBooks()
        {
            Console.WriteLine("Library Catalog:");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        public void BorrowBook(string title)
        {
	    Book? book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null && book.IsAvailable)
            {
                book.IsAvailable = false;
                Console.WriteLine($"Successfully borrowed: {book.Title}");
            }
            else if (book != null)
            {
                Console.WriteLine($"Sorry, {book.Title} is already borrowed.");
            }
            else
            {
                Console.WriteLine("Book not found in the library.");
            }
        }
    }
}
