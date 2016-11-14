using System.Collections.Generic;

namespace MbmStore.DAL
{
    public interface IProductRepository<TEntity>
    {
        IEnumerable<TEntity> GetProductList();
        TEntity GetProductById(int id);
        void SaveProduct(TEntity product);
        TEntity DeleteProduct(int id);

    }
}
