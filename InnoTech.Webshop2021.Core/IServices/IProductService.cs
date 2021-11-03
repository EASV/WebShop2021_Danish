using System.Collections.Generic;
using InnoTech.Webshop2021.Core.Models;

namespace InnoTech.Webshop2021.Core.IServices
{
    public interface IProductService
    {
        List<Product> GetAll();
    }
}