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
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _unit;

        public ClientController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        [HttpGet]
        
        public  async Task<IActionResult> GetAll() 
        { 
            var clients = await _unit.ClientRepository.GetAll();
            return Ok (clients);
        }
        [HttpPost]
        public  async Task< IActionResult> Add(ClientDto clientDto)
        {
            var client = new Client
            {
                Name = clientDto.Name,
                PhonNumber = clientDto.PhonNumber,
            };
            await  _unit.ClientRepository.Add(client);
            _unit.Save();
            return Ok(client);

        }
        [HttpPut("{id}")]
        public async Task< IActionResult> Update( int id,[FromBody] ClientDto clientDto)
        {
            if (clientDto == null)
            {
                return BadRequest("Invalid client data.");
            }
            var client = await _unit.ClientRepository.GitById(id);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                client.Name =  clientDto.Name;
                client.PhonNumber = clientDto.PhonNumber;
                _unit.ClientRepository.Update(client);
                _unit.Save();
            }
            return Ok(client);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int  id)
        {
            var client = await _unit.ClientRepository.GitById(id);

            if (client == null)
                return NotFound($"No client was found with ID: {id}");

            _unit.ClientRepository.Delete(id);
            _unit.Save();

            return Ok("Deleted Successfully");
        }

    }
}
