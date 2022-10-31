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
        public IResult Get()
        {
            var products = productService.GetAll();
            var result = mapper.Map<IEnumerable<ProductVM>>(products);
            return Results.Ok(result);
        }

        [HttpGet("{lower:int:min(0)}-{upper:int}")]
        public IResult GetByPrice(int lower, int upper)
        {
            var products = productService.GetProductsByPriceRange(lower, upper);
            var result =  mapper.Map<IEnumerable<ProductVM>>(products);
            return Results.Ok(result);
        }

        [HttpGet("{id:int:min(1)}")]
        public IResult Get(int id)
        {
            var p = productService.GetProduct(id);

            if (p is null)
                return Results.BadRequest();

            var result = mapper.Map<ProductVM>(p);
            return Results.Ok(result);
        }

        [HttpPost]
        public IResult Post([FromBody] NewProductVM product)
        {
            if (ModelState.IsValid is false)
            {
                var errorDictionary = ModelState.AsValidationDictionary();
                return Results.ValidationProblem(errorDictionary);
            }

            var p = mapper.Map<NewProductVM, Product>(product);
            productService.AddProduct(p);
            return Results.Ok();
        }

        [HttpPut("{id:int:min(1)}")]
        public IResult Put(int id, [FromBody] ProductVM product)
        {
            if (ModelState.IsValid is false)
            {
                var errorDictionary = ModelState.AsValidationDictionary();
                return Results.ValidationProblem(errorDictionary);
            }

            var p = productService.GetProduct(id); 
            mapper.Map(product, p);
            productService.UpdateProduct(p);
            return Results.Ok();
        }

        [HttpDelete("{id:int:min(1)}")]
        public IResult Delete(int id)
        {
            productService.DeleteProduct(id);
            return Results.Ok();
        }
    }
}
