using MbmStore.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class NavController : Controller
    {
        private MbmStoreContext db;

        public NavController()
        {
            db = new MbmStoreContext();
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = db.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}