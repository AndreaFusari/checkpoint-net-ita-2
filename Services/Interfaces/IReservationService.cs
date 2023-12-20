using net_ita_2_checkpoint.DTOs;
using net_ita_2_checkpoint.Entities;

namespace net_ita_2_checkpoint.Services.Interfaces
{
    public interface IReservationService
    {
        Task CreateAsync(RoomReservationDTO reservation);
        Task<List<Room>> GetAllAsync();
    }
}
