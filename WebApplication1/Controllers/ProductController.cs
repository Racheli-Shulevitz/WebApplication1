using Microsoft.AspNetCore.Mvc;
using Services;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Entities;
using AutoMapper;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OurStore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMapper mapper;
        IProductService ProductService;
        public ProductController(IProductService _ProductService, IMapper _mapper)
        {
            ProductService = _ProductService;
            mapper = _mapper;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get([FromQuery] string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            List<Product> productList = await ProductService.Get( desc,  minPrice,maxPrice, categoryIds);
            List<ProductDTO> productListDTO = mapper.Map<List<Product>,List<ProductDTO>>(productList);
            return productListDTO != null? Ok(productListDTO) :BadRequest();
        }

        // GET api/<ProductController>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> Get(int id)
        //{
        //    ////doesnt workkkkkkkk
        //    Product product = await ProductService.Get(id);
        //    return product != null ? Ok() : BadRequest();
        //}

        //// POST api/<ProductController>
        //[HttpPost]
        //public async Task<ActionResult<Product>> Post([FromBody] Product product)
        //{
        //    Product newProduct = await ProductService.Post(product);
        //    if (newProduct == null)
        //        return BadRequest();
        //    return CreatedAtAction(nameof(Get), new { id = product.ProductId }, product);
        //}

        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public async Task<ActionResult<Product>> Put(int id, [FromBody] Product product)
        //{
        //    Product newP = await ProductService.Put(id, product);
        //    return newP == null ? BadRequest() : Ok(newP);
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Product>> Delete(int id)
        //{
        //}
    }
}
