using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC5Course.Models
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }

        public override IQueryable<Product> All()
        {
            return All(false);
        }

        public IQueryable<Product> All(bool IsDelete)
        {
            return base.All().Where(p => p.IsDelete == IsDelete);
        }
    }

    public interface IProductRepository : IRepository<Product>
    {

    }
}