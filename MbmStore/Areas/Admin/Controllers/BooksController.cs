﻿using MbmStore.DAL;
using MbmStore.Models;
using System.Data;
using System.Net;
using System.Web.Mvc;

namespace MbmStore.Areas.Admin.Controllers
{
    public class BooksController : Controller
    {
        private ProductRepository<Book> repo = new ProductRepository<Book>();

        // GET: Admin/Books
        public ActionResult Index()
        {
            return View(repo.GetList());
        }

        // GET: Admin/Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = repo.GetById((int)id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Admin/Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title, Price, ImageUrl, Category, Author, Publisher, Published, ISBN")] Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.SaveItem(book);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                // Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(book);
        }

        // GET: Admin/Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = repo.GetById((int)id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Admin/Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Title,Price,ImageUrl,Category,Author,Publisher,Published,ISBN")] Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.SaveItem(book);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                // Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(book);
        }

        // GET: Admin/Books/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your administrator.";
            }

            Book book = repo.GetById((int)id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Admin/Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Book book = repo.DeleteItem(id);
            }
            catch (DataException /* dex */ )
            {
                // Log the error (uncomment dex variable name and add a line here to write a log.)
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }

    }
}
