using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MbmStore.DAL
{
    public class ProductRepository<TEntity> where TEntity : Product
    {
        MbmStoreContext context = new MbmStoreContext();
        DbSet<TEntity> dbSet;

        public ProductRepository()
        {
            dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetList()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();
        }

        public TEntity GetProductById(int id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// TODO: Needs fixing. How to implement this functionality in a generic way?
        /// </summary>
        /// <param name="product"></param>
        public void SaveProduct(TEntity product)
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

        public TEntity DeleteProduct(int id)
        {
            TEntity product = dbSet.Find(id);
            if (product != null)
            {
                dbSet.Remove(product);
                context.SaveChanges();
            }
            return product;

        }


    }
}