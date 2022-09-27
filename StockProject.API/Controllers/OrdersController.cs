using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockProject.Bussiness.Interfaces;
using StockProject.Dtos.OrderDtos;

namespace StockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(OrderCreateDto orderCreateDto)
        {
            var created = await _service.CreateAsync(orderCreateDto);
            if (created == null)
            {
                return BadRequest(orderCreateDto);
            }
            return Created(string.Empty, created);
        }


        //[Authorize(Roles = "Admin")]
        [HttpPut("update")]
        public async Task<IActionResult> Update(OrderUpdateDto orderUpdateDto)
        {

            var updated = await _service.UpdateAsync(orderUpdateDto);

            if (updated == null)
            {
                return BadRequest(orderUpdateDto);
            }
            return Ok(orderUpdateDto);
        }

        //[Authorize]
        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var orderList = await _service.GetAllAsync();
            if (orderList == null)
            {
                return BadRequest();
            }
            return Ok(orderList);
        }


        //[Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _service.RemoveAsync(id);
            return NoContent();
        }

    }
}
