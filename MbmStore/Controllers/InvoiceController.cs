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
            ViewBag.Invoices = db.Invoices.Include("OrderItems");

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

            IEnumerable<Invoice> invoices;

            if (CustomerId != null)
            {
                // select invoices for a customer with linq
                invoices = db.Invoices.Include("OrderItems").Where(r => r.Customer.CustomerId == CustomerId);
            }
            else
            {
                invoices = db.Invoices.Include("OrderItems");
            }
            ViewBag.Invoices = invoices;



            return View();
        }
    }
}