using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OurStore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IMapper mapper;
        ICategoryService categoryService;
        public CategoryController(ICategoryService _CategoryService, IMapper _mapper)
        {
            categoryService = _CategoryService;
            mapper = _mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> Get()
        {
            List<Category> categories = await categoryService.Get();
            List<CategoryDTO> categoriesDTO = mapper.Map<List<Category>, List<CategoryDTO>>(categories);
            return categoriesDTO != null ? Ok(categoriesDTO) : BadRequest();
        }
    //
    //    // GET api/<CategoryController>/5
    //    [HttpGet("{id}")]
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST api/<CategoryController>
    //    [HttpPost]
    //    public void Post([FromBody] string value)
    //    {
    //    }

    //    // PUT api/<CategoryController>/5
    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody] string value)
    //    {
    //    }

    //    // DELETE api/<CategoryController>/5
    //    [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //    }
    }
}
