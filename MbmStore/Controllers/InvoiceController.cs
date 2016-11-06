using MbmStore.DAL;
using MbmStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class InvoiceController : Controller
    {
        private MbmStoreContext db;

        public InvoiceController()
        {
            db = new MbmStoreContext();
        }

        // GET: Invoice
        public ActionResult Index()
        {
            ViewBag.Invoices = db.Invoices;


            // generete dropdown list
            List<SelectListItem> customers = new List<SelectListItem>();
            foreach (Invoice invoice in db.Invoices)
            {
                customers.Add(new SelectListItem { Text = invoice.Customer.Firstname + " " + invoice.Customer.Lastname, Value = invoice.Customer.CustomerId.ToString() });
            }
            // removes duplicate entries with same ID from a IEnumerable
            customers = customers.GroupBy(x => x.Value).Select(y => y.First()).OrderBy(z => z.Text).ToList<SelectListItem>();

            ViewBag.CustomerId = customers;
            return View();
        }


        [HttpPost]
        public ActionResult Index(int? CustomerId)
        {
            // generete dropdown list
            List<SelectListItem> customers = new List<SelectListItem>();
            foreach (Invoice invoice in db.Invoices)
            {
                customers.Add(new SelectListItem { Text = invoice.Customer.Firstname + " " + invoice.Customer.Lastname, Value = invoice.Customer.CustomerId.ToString() });

            }

            // removes duplicate entries with same ID from a IEnumerable
            customers = customers.GroupBy(x => x.Value).Select(y => y.First()).OrderBy(z => z.Text).ToList<SelectListItem>();

            ViewBag.CustomerID = customers;

            IEnumerable<Invoice> invoices = db.Invoices;

            if (CustomerId != null)
            {
                // select invoices for a customer with linq
                invoices = db.Invoices.Where(r => r.Customer.CustomerId == CustomerId);
            }
            ViewBag.Invoices = invoices;



            return View();
        }
    }
}