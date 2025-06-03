using BooksApi.Entities.Entities;
using BooksApi.Entities.Repositories.Interface;
using BooksApi.Models;
using BooksApi.Services.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Services
{
    // For CRUD on books
    public class BookService : IBookService
    {
        private List<Book> _books;
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _books = new List<Book>();
        }

        // To Add Book
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        // To Get All Books
        public List<Book> GetAll()
        {
            return _books;
        }

        // To Get Single Book
        public Book? GetBookById(int id)
        {
            return _books.Find(x => x.Id == id);
        }

        public async Task InsertBook(BookDetails bookDetails)
        {
            await _bookRepository.InsertBook(bookDetails);
        }


        public BookDetails GetBookDetailsById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public async Task<bool> UpdateBookAsync(BookDetails updatedBook)
        {
            var existingBook = _bookRepository.GetById(updatedBook.Id);
            if (existingBook == null)
                return false;

            // Update fields
            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.Description = updatedBook.Description;
            // Add more fields as needed

            await _bookRepository.UpdateBookAsync(existingBook);
            return true;
        }

        // Delete Book
        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
                return false;

            await _bookRepository.DeleteBookAsync(id);
            return true;
        }
    }
}
