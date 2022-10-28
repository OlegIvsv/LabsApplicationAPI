using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplicationAPI.Interfaces;
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
        public IEnumerable<object> Get()
        {
            return productService.GetAll();
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            return productService.GetProduct(id);
        }

        [HttpPost]
        public void Post([FromBody] ProductVM product)
        {
            var dtoModel = mapper.Map<ProductVM, ProductDTO>(product);
            productService.AddProduct(dtoModel);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductVM product)
        {
            var dtoModel = mapper.Map<ProductVM, ProductDTO>(product);
            productService.UpdateProduct(dtoModel);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productService.DeleteProduct(id);
        }
    }
}
