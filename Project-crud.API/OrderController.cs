using Microsoft.AspNetCore.Mvc;
using ProjectCrud.Application.Services;
using ProjectCrud.Domain.DTOs;

namespace ProjectCrud.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _orderService.FindAllAsync();
            if (result.Sucess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet, Route("{orderId}")]
        public async Task<IActionResult> GetAsync(Guid orderId)
        {
            var result = await _orderService.FindByIdAsync(orderId);
            if (result.Sucess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OrderDto orderDto)
        {
            var result = await _orderService.CreateAsync(orderDto);

            if (result.Sucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete, Route("{orderId}")]
        public async Task<IActionResult> DeleteAsync(Guid orderId)
        {
            var result = await _orderService.DeleteAsync(orderId);

            if (result.Sucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
