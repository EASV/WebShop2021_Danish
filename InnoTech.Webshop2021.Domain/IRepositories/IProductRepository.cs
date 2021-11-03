using System.Collections.Generic;
using InnoTech.Webshop2021.Core.Models;

namespace InnoTech.Webshop2021.Domain.IRepositories
{
    public interface IProductRepository
    {
        List<Product> ReadAll();
    }
}