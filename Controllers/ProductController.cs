using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplicationAPI.Interfaces;
using LabsApplicationAPI.Models;
using LabsApplicationAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LabsApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService productService;
        private IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ProductVM> Get()
        {
            var products = productService.GetAll();
            return mapper.Map<IEnumerable<ProductVM>>(products);
        }

        [HttpGet("{id}")]
        public ProductVM Get(int id)
        {
            var p = productService.GetProduct(id);
            return mapper.Map<ProductVM>(p);
        }

        [HttpPost]
        public void Post([FromBody] ProductVM product)
        {
            var p = mapper.Map<ProductVM, Product>(product);
            productService.AddProduct(p);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductVM product)
        {
            var p = mapper.Map<ProductVM, Product>(product);
            productService.UpdateProduct(p);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productService.DeleteProduct(id);
        }
    }
}
