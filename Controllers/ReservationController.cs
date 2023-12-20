using Microsoft.AspNetCore.Mvc;
using net_ita_2_checkpoint.DTOs;
using net_ita_2_checkpoint.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace net_ita_2_checkpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _service;

        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        // GET: api/<ReservationController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           return Ok(await _service.GetAllAsync());
           
            
        }


        // POST api/<ReservationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoomReservationDTO dto )
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

     
    }
}
