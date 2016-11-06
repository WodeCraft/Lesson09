using MbmStore.DAL;
using MbmStore.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class CatalogueController : Controller
    {

        private MbmStoreContext db;
        public int PageSize = 4;

        // GET: Catalogue
        public ActionResult Index(string category, int page = 1)
        {
            db = new MbmStoreContext();

            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = db.Products
                .Where(p => category == null || p.Category == category)
               .OrderBy(p => p.ProductId)
               .Skip((page - 1) * PageSize)
               .Take(PageSize).ToList(),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    db.Products.Count() :
                    db.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}