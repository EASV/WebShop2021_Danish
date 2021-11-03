using System.Collections.Generic;
using System.IO;
using System.Linq;
using InnoTech.Webshop2021.Core.IServices;
using InnoTech.Webshop2021.Core.Models;
using InnoTech.Webshop2021.Domain.IRepositories;

namespace InnoTech.Webshop2021.Domain.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            if (productRepository == null)
            {
                throw new InvalidDataException("ProductRepository Cannot be Null");
            }

            _productRepository = productRepository;
        }

        public List<Product> GetAll()
        {
            return _productRepository.ReadAll();
        }
    }
}