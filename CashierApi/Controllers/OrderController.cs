using CashierDataAccess.DTOs;
using CashierDataAccess.Models;
using CashierDataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashierApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unit;

        public OrderController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        [HttpGet]
        public  async Task<IActionResult> GetAll() 
        { 
            var Orders = await _unit.OrderRepository.GetAll();
            return Ok (Orders);
        }
        [HttpPost]
        public  async Task< IActionResult> Add(OrderDto orderDto)
        {
            var order = new Order
            {
                ClientID = orderDto.ClientID,
                PaidAmount = orderDto.PaidAmount,
                TotalAmount = orderDto.TotalAmount,
                DilveryTime = orderDto.DilveryTime,
               
            };
            await  _unit.OrderRepository.Add(order);
            _unit.Save();
            return Ok(order);

        }
        [HttpPut("{id}")]
        public async Task< IActionResult> Update( int id,[FromBody] OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Invalid client data.");
            }
            var order = await _unit.OrderRepository.GitById(id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                order.ClientID=orderDto.ClientID;
                order.PaidAmount=orderDto.PaidAmount;
                order.TotalAmount=orderDto.TotalAmount;
                order.DilveryTime=orderDto.DilveryTime;
                _unit.OrderRepository.Update(order);
                _unit.Save();
            }
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int  id)
        {
            var order = await _unit.OrderRepository.GitById(id);

            if (order == null)
                return NotFound($"No client was found with ID: {id}");

            _unit.OrderRepository.Delete(id);
            _unit.Save();

            return Ok("Deleted Successfully");
        }

    }
}
