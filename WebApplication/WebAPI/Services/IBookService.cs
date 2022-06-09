using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.Database;

namespace WebAPI.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync();
        Task UpdateBookAsync(int bookId, Book book);
        Task CreateBookAsync(Book book);
        Task DeleteBookAsync(int bookId);
    }

    public class BookService : IBookService
    {
        private readonly BookDbContext _bookDbContext;

        public BookService(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            var test = await _bookDbContext.Books.ToListAsync() ?? new List<Book>();
            return test;
        }

        public async Task UpdateBookAsync(int bookId, Book book)
        {
            var currentBook = await _bookDbContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);
            currentBook.Title = book.Title;

            await _bookDbContext.SaveChangesAsync();
        }

        public async Task CreateBookAsync(Book book)
        {
            _bookDbContext.Books.Add(new Book {Title = book.Title, Author = new Author {Name = book.Author.Name}});
            await _bookDbContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = await _bookDbContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);
            _bookDbContext.Books.Remove(book);

            await _bookDbContext.SaveChangesAsync();
        }
    }
}