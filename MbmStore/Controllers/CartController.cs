using MbmStore.DAL;
using MbmStore.Models;
using MbmStore.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class CartController : Controller
    {
        private MbmStoreContext db;

        // constructor
        // instantiale a new repository object
        public CartController()
        {
            db = new MbmStoreContext();
        }


        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }


        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = db.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { controller = returnUrl.Substring(1) });
        }


        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = db.Products
            .FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                cart.RemoveItem(product);
            }
            return RedirectToAction("Index", new { controller = returnUrl.Substring(1) });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }


        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                // order processing logic
                Customer customer = new Customer
                {
                    Firstname = shippingDetails.Firstname,
                    Lastname = shippingDetails.Lastname,
                    Address = shippingDetails.Address,
                    Zip = shippingDetails.Zip,
                    Email = shippingDetails.Email
                };

                if (db.Customers.Any(c => c.Firstname == customer.Firstname
                    && c.Lastname == customer.Lastname
                    && c.Email == customer.Email))
                {
                    customer = db.Customers.Where(c => c.Firstname == customer.Firstname
                                            && c.Lastname == customer.Lastname
                                            && c.Email == customer.Email).First();
                    customer.Address = shippingDetails.Address;
                    customer.Zip = shippingDetails.Zip;
                    // ensure update instead of insert 
                    db.Entry(customer).State = EntityState.Modified;
                }

                int nextInvoiceId = db.Invoices.OrderByDescending(i => i.InvoiceId).First().InvoiceId + 1;

                Invoice invoice = new Invoice(nextInvoiceId, DateTime.Now, customer);

                foreach (CartLine line in cart.Lines)
                {
                    OrderItem orderItem = new OrderItem(line.Product, line.Quantity);
                    //orderItem.ProductId = line.Product.ProductId;
                    orderItem.Product = null;
                    invoice.OrderItems.Add(orderItem);
                }

                db.Invoices.Add(invoice);
                db.SaveChanges();

                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

    }
}