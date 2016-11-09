using MbmStore.DAL;
using MbmStore.Models;
using System.Data;
using System.Net;
using System.Web.Mvc;

namespace MbmStore.Areas.Admin.Controllers
{
    public class MoviesController : Controller
    {
        private EFMovieRepository repo = new EFMovieRepository();

        // GET: Admin/Movies
        public ActionResult Index()
        {
            return View(repo.GetMovieList());
        }

        // GET: Admin/Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = repo.GetMovieById((int)id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Admin/Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title, Price, ImageUrl, Category, Director")] Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.SaveMovie(movie);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                // Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(movie);
        }

        // GET: Admin/Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = repo.GetMovieById((int)id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Admin/Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId, Title, Price, ImageUrl, Category, Director")] Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.SaveMovie(movie);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                // Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(movie);
        }

        // GET: Admin/Movies/Delete/5
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

            Movie movie = repo.GetMovieById((int)id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Admin/Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Movie movie = repo.GetMovieById((int)id);
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
