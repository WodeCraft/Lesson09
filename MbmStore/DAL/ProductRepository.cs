using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MbmStore.DAL
{
    public class ProductRepository<T> : IRepository<T> where T : Product
    {
        MbmStoreContext context = new MbmStoreContext();
        DbSet<T> dbSet;

        public ProductRepository()
        {
            dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetList()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public void SaveItem(T product)
        {
            if (product.ProductId == 0)
            {
                product.CreatedDate = DateTime.Now;
                dbSet.Add(product);
                context.SaveChanges();
            }
            else
            {
                context.Entry(product).State = EntityState.Modified;
                context.Entry(product).Property(b => b.CreatedDate).IsModified = false;
                context.SaveChanges();
            }
        }

        public T DeleteItem(int id)
        {
            T product = dbSet.Find(id);
            if (product != null)
            {
                dbSet.Remove(product);
                context.SaveChanges();
            }
            return product;

        }


    }
}