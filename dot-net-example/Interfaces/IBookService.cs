using dot_net_example.Models;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_example.Services.Interfaces
{
    public interface IBookService
    {
        public void DeleteBook(long id);

        public ActionResult<IEnumerable<Book>> GetBooks();

        public ActionResult<Book> GetBook(long id);

        public void PostBook(Book book);

        public void PutBook(long id, Book book);

        public void CheckIfBookExists(long id);
    }
}
