using MbmStore.Models;
using MbmStore.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;

namespace MbmStore.DAL
{
    public class EFInvoiceRepository : IInvoiceRepository
    {
        MbmStoreContext db = new MbmStoreContext();

        public Product GetProductById(int productId)
        {
            // TODO Will only work if all products have unique IDs!!
            return db.Products.Find(productId);
        }

        public void SaveInvoice(Cart cart, ShippingDetails shippingDetails)
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

            int nextInvoiceId = db.Invoices.Max(i => i.InvoiceId) + 1;

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
        }
    }
}