using MbmStore.DAL;
using MbmStore.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MbmStore.Areas.Admin.Controllers
{
    public class MusicController : Controller
    {
        private MbmStoreContext db = new MbmStoreContext();

        // GET: Admin/Music
        public ActionResult Index()
        {
            return View(db.MusicCDs.ToList());
        }

        // GET: Admin/Music/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicCD musicCD = db.MusicCDs.Find(id);
            if (musicCD == null)
            {
                return HttpNotFound();
            }
            return View(musicCD);
        }

        // GET: Admin/Music/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Music/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title, Price, ImageUrl, Category, Artist, Label, Released")] MusicCD musicCD)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    musicCD.CreatedDate = DateTime.Now;
                    db.MusicCDs.Add(musicCD);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                // Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(musicCD);
        }

        // GET: Admin/Music/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicCD musicCD = db.MusicCDs.Find(id);
            if (musicCD == null)
            {
                return HttpNotFound();
            }
            return View(musicCD);
        }

        // POST: Admin/Music/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId, Title, Price, ImageUrl, Category, Artist, Label, Released")] MusicCD musicCD)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(musicCD).State = EntityState.Modified;
                    db.Entry(musicCD).Property(c => c.CreatedDate).IsModified = false;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                // Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(musicCD);
        }

        // GET: Admin/Music/Delete/5
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

            MusicCD musicCD = db.MusicCDs.Find(id);
            if (musicCD == null)
            {
                return HttpNotFound();
            }
            return View(musicCD);
        }

        // POST: Admin/Music/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                MusicCD musicCD = db.MusicCDs.Find(id);
                db.MusicCDs.Remove(musicCD);
                // Alternative to the lines above. A performance improvement
                //MusicCD MusicCDToDelete = new MusicCD() { ProductId = id };
                //db.Entry(MusicCDToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (DataException /* dex */ )
            {
                // Log the error (uncomment dex variable name and add a line here to write a log.)
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
