using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
using System;
using DTO;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OurStore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IMapper mapper;
        IOrderService orderService;

        public OrderController(IOrderService _orderService, IMapper _mapper)
        {
            orderService = _orderService;
            mapper = _mapper;
        }
        //// GET: api/<OrderController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            Order order = await orderService.Get(id);
            OrderDTO orderDTO = mapper.Map<Order, OrderDTO>(order);
            return orderDTO != null ? Ok(orderDTO): NoContent();
           
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] AddOrderDTO order)
        {
            Order? newOrder = await orderService.Post(mapper.Map<AddOrderDTO, Order>(order));
            OrderDTO newOrderDTO = mapper.Map<Order, OrderDTO>(newOrder);
            if (newOrderDTO != null)
                return Ok(newOrderDTO); CreatedAtAction(nameof(Get), new { id = newOrderDTO.OrderId }, newOrderDTO);
            return BadRequest();
        }

        //// PUT api/<OrderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<OrderController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
