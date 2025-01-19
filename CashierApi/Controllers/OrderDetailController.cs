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
    public class OrderDetailController : ControllerBase
    {
        private readonly IUnitOfWork _unit;

        public OrderDetailController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        [HttpGet]
        public  async Task<IActionResult> GetAll() 
        { 
            var OrderDetails = await _unit.OrderDetailRepository.GetAll();
            return Ok (OrderDetails);
        }
        [HttpPost]
        public  async Task< IActionResult> Add(OrderDetailDto orderDetailDto)
        {
            var orderDetails = new OrderDetail
            {
               OrderID= orderDetailDto.OrderID,
               Shoulder= orderDetailDto.Shoulder,
               SizeOfNeck= orderDetailDto.SizeOfNeck,
               CollarSize= orderDetailDto.CollarSize,
               KikLength= orderDetailDto.KikLength,
               Length= orderDetailDto.Length,
               NumberofTops=orderDetailDto.NumberofTops,
               SleeveLength= orderDetailDto.SleeveLength,
               HandExpansion= orderDetailDto.HandExpansion,
               ChestExpansion= orderDetailDto.ChestExpansion,
               
            };
            await  _unit.OrderDetailRepository.Add(orderDetails);
            _unit.Save();
            return Ok(orderDetails);

        }
        [HttpPut("{id}")]
        public async Task< IActionResult> Update( int id,[FromBody] OrderDetailDto orderDetailDto)
        {
            if (orderDetailDto == null)
            {
                return BadRequest("Invalid client data.");
            }
            var orderDetail = await _unit.OrderDetailRepository.GitById(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            else
            {
                orderDetail.SizeOfNeck = orderDetailDto.SizeOfNeck;
                orderDetail.CollarSize = orderDetailDto.CollarSize;
                orderDetail.KikLength = orderDetailDto.KikLength;
                orderDetail.Length = orderDetailDto.Length;
                orderDetail.NumberofTops = orderDetailDto.NumberofTops;
                orderDetail.HandExpansion = orderDetailDto.HandExpansion;
                orderDetail.ChestExpansion = orderDetailDto.ChestExpansion;
                orderDetailDto.OrderID= orderDetail.OrderID;
                orderDetailDto.Shoulder= orderDetailDto.Shoulder;
                orderDetailDto.SleeveLength = orderDetailDto.SleeveLength;
                _unit.OrderDetailRepository.Update(orderDetail);
                _unit.Save();
            }
            return Ok(orderDetail);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int  id)
        {
            var order = await _unit.OrderDetailRepository.GitById(id);

            if (order == null)
                return NotFound($"No client was found with ID: {id}");

            _unit.OrderDetailRepository.Delete(id);
            _unit.Save();

            return Ok("Deleted Successfully");
        }

    }
}
