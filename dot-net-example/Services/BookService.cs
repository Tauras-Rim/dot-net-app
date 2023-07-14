using dot_net_example.Models;
using dot_net_example.Services.Classes;
using dot_net_example.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dot_net_example.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _libraryContext;
        private readonly ICustomerService _customerService;

        public BookService(LibraryContext libraryContext, ICustomerService customerService)
        {
            _libraryContext = libraryContext;
            _customerService = customerService;
        }

        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return _libraryContext.Books.ToList();
        }

        public void PostBook(Book book)
        {
            if(book.CustomerId != null)
            {
                _customerService.CheckIfCustomerExists((long)book.CustomerId);
            }
            _libraryContext.Books.Add(book);
            _libraryContext.SaveChanges();
        }
        public void DeleteBook(long id)
        {
            CheckIfBookExists(id);

            var book = _libraryContext.Books.Find(id);

            _libraryContext.Books.Remove(book);
            _libraryContext.SaveChanges();
        } 
                
        public void PutBook(long id, Book book)
        {
            CheckIfBookExists(id);

            _libraryContext.Entry(book).State = EntityState.Modified;

            _libraryContext.SaveChanges();
        }

        public ActionResult<Book> GetBook(long id)
        {
            CheckIfBookExists(id);

            return _libraryContext.Books.Find(id);
        }

        public void CheckIfBookExists(long id)
        {
            if (!_libraryContext.Books.Any(e => e.Id == id))
                throw new ArgumentException("Book with id " + id + " not found");
        }
    }
}
