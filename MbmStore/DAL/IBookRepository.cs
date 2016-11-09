using MbmStore.Models;
using System.Collections.Generic;

namespace MbmStore.DAL
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBookList();
        Book GetBookById(int id);
        void SaveBook(Book book);
        Book DeleteBook(int bookId);
    }
}