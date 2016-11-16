using MbmStore.Models;
using MbmStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MbmStore.DAL
{
    public class InvoiceRepository<T> : IRepository<T> where T : Invoice
    {
        MbmStoreContext context = new MbmStoreContext();
        DbSet<T> dbSet;

        public InvoiceRepository()
        {
            dbSet = context.Set<T>();
        }

        public T DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public Product GetProductById(int productId)
        {
            return context.Products.Find(productId);
        }

        public IEnumerable<T> GetList()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void SaveItem(T item)
        {
            throw new NotImplementedException();
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

            if (context.Customers.Any(c => c.Firstname == customer.Firstname
                && c.Lastname == customer.Lastname
                && c.Email == customer.Email))
            {
                customer = context.Customers.Where(c => c.Firstname == customer.Firstname
                                        && c.Lastname == customer.Lastname
                                        && c.Email == customer.Email).First();
                customer.Address = shippingDetails.Address;
                customer.Zip = shippingDetails.Zip;
                // ensure update instead of insert 
                context.Entry(customer).State = EntityState.Modified;
            }

            int nextInvoiceId = context.Invoices.Max(i => i.InvoiceId) + 1;

            Invoice invoice = new Invoice(nextInvoiceId, DateTime.Now, customer);

            foreach (CartLine line in cart.Lines)
            {
                OrderItem orderItem = new OrderItem(line.Product, line.Quantity);
                orderItem.Price = line.Price;
                orderItem.ProductId = line.Product.ProductId;
                orderItem.Product = null;
                invoice.OrderItems.Add(orderItem);
            }

            context.Invoices.Add(invoice);
            context.SaveChanges();

            cart.Clear();

        }
    }
}