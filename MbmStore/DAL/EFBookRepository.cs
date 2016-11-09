using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MbmStore.DAL
{
    public class EFBookRepository : IBookRepository
    {
        MbmStoreContext db = new MbmStoreContext();

        public IEnumerable<Book> GetBookList()
        {
            return db.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return db.Books.Find(id);
        }

        public void SaveBook(Book book)
        {
            if (book.ProductId == 0)
            {
                book.CreatedDate = DateTime.Now;
                db.Books.Add(book);
                db.SaveChanges();
            }
            else
            {
                db.Entry(book).State = EntityState.Modified;
                db.Entry(book).Property(b => b.CreatedDate).IsModified = false;
                db.SaveChanges();
            }
        }

        public Book DeleteBook(int bookId)
        {
            Book book = db.Books.Find(bookId);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
            return book;
        }

    }
}