using System.Collections.Generic;
using System.Linq;
using InnoTech.Webshop2021.Core.Models;
using InnoTech.Webshop2021.Domain.IRepositories;

namespace InnoTech.Webshop2021.DataAccess.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly MainDbContext _ctx;

        public ProductRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Product> ReadAll()
        {
            return _ctx.Products
                .Select(pe => new Product
                {
                    Id = pe.Id,
                    Name = pe.Name
                })
                .ToList();
        }
    }
}