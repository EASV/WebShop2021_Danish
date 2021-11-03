using System.Collections.Generic;
using InnoTech.Webshop2021.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.Webshop2021.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ProductsDto> ReadAll()
        {
            //Herfra
            var dto = new ProductsDto();
            dto.List = new List<ProductDto>
            {
                new ProductDto {Id = 1, Name = "Ost"},
                new ProductDto {Id = 2, Name = "Ostekiks"},
                new ProductDto {Id = 3, Name = "Smølf"}
            };
            //Hertil
            return Ok(dto);
        }
    }
}