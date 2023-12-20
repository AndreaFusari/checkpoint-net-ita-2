using net_ita_2_checkpoint.Context;
using net_ita_2_checkpoint.DTOs;
using net_ita_2_checkpoint.Entities;
using net_ita_2_checkpoint.Services.Interfaces;

namespace net_ita_2_checkpoint.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IDbContext _db;

        public ReservationService(IDbContext db)
        {
            _db = db;
        }

       
        public async Task CreateAsync(RoomReservationDTO reservation)
        {
            _db.Reservations.Add(new Reservation()
            {
                Date = reservation.Date,
                People = reservation.People,
                RoomId = reservation.RoomId
            }) ;
        }

        public async Task<List<Room>> GetAllAsync()
        {
            return _db.Rooms.ToList();
        }

    }
}
