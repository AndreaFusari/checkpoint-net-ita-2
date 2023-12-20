using Microsoft.AspNetCore.Mvc;
using net_ita_2_checkpoint.DTOs;
using net_ita_2_checkpoint.Services.Interfaces;

namespace net_ita_2_checkpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllRoomsAsync()
        {
            return Ok(await _service.GetAllRoomsAsync());
            
        }

        [HttpGet("Available")]
        public async Task<IActionResult> GetAvailableRoomsAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        [HttpGet("Detail")]
        public async Task<IActionResult> GetRoomAsync(Guid id)
        {
           return Ok(await _service.GetRoomAsync(id));
            
        }

        [HttpPost]
        public async Task<IActionResult> PostRoomAsync([FromBody] CreateRoomDTO dto)
        {
           await _service.CreateRoomAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutRoomAsync(Guid id , UpdateRoomDTO dto)
        {
            await _service.UpdateRoomAsync(id, dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRoomAsync(Guid id)
        {
           await _service.DeleteRoomAsync(id);
           return Ok();
           
            
        }
    }
}