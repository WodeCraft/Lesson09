using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MbmStore.Models
{
    public class Invoice
    {

        private decimal totalPrice;
        private List<OrderItem> orderItems = new List<OrderItem>();

        public int CustomerId { get; set; }

        public int InvoiceId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice
        {
            get
            {
                totalPrice = 0;
                foreach (OrderItem orderItem in orderItems)
                {
                    totalPrice += orderItem.TotalPrice;
                }
                return totalPrice;

                // with linq
                //return orderItems.Sum(e => e.Product.Price * e.Quantity);
            }
        }

        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get { return orderItems; } set { orderItems = value; } }

        public Invoice() { }

        public Invoice(int invoiceId, DateTime orderDate, Customer customer)
        {
            InvoiceId = invoiceId;
            OrderDate = orderDate;
            Customer = customer;
        }

        public void AddOrderItem(Product product, int quantity)
        {

            OrderItem item = orderItems.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();

            if (item == null)
            {
                orderItems.Add(new OrderItem(product, quantity));
            }
            else
            {
                item.Quantity += quantity;
            }
        }
    }
}