using net_ita_2_checkpoint.Context;
using net_ita_2_checkpoint.DTOs;
using net_ita_2_checkpoint.Entities;
using net_ita_2_checkpoint.Services.Interfaces;

namespace net_ita_2_checkpoint.Services
{
    public class RoomService : IRoomService
    {
        private readonly IDbContext _db;

        public RoomService(IDbContext db)
        {
            _db = db;
        }

        public async Task CreateRoomAsync(CreateRoomDTO dto)
        {
            var room = new Room()
            {
                Name = dto.Name,
                Type = dto.Type,
                People = dto.People,
                Price = dto.Price
            };

            _db.Rooms.Add(room);


        }

        public async Task DeleteRoomAsync(Guid id)
        {
            var room = _db.Rooms.Find(r => r.Id == id) ?? throw new Exception("Null Value");
            _db.Rooms.Remove(room);

        }

        public async Task UpdateRoomAsync(Guid id, UpdateRoomDTO dto)
        {

            var room = _db.Rooms.Find(r => r.Id == id) ?? throw new Exception("Null Value");

            room.Name = dto.Name;
            room.Type = dto.Type;
            room.People = dto.People;
            room.Price = dto.Price;

        }

        public async Task<ICollection<RoomListDTO>> GetAllRoomsAsync()
        {
            return _db.Rooms.Select(r => new RoomListDTO()
            {
                Id = r.Id,
                Name = r.Name,
                Type = r.Type,
                People = r.People,
                Price = r.Price

            }).ToList();
        }



        public async Task<RoomDetailDTO> GetRoomAsync(Guid id)
        {
            return _db.Rooms.GroupJoin(
                _db.Reservations,
                room => room.Id,
                reservation => reservation.RoomId,
                (room, reservations) => new RoomDetailDTO()
                {
                    Id = room.Id,
                    Name = room.Name,
                    Type = room.Type,
                    People = room.People,
                    Price = room.Price,
                    Reservations = reservations.Select(r => new RoomReservationDTO()
                    {
                        Date = r.Date,
                        People = r.People,
                        RoomId = r.RoomId
                    }).ToList()
                }).FirstOrDefault(r => r.Id == id) ?? throw new Exception("Null Value");

        }

        public async Task<ICollection<RoomListDTO>> GetAvailableRoomsAsync(DateTime date)
        {
            return _db.Rooms.Where(room => !_db.Reservations.Any(r => r.RoomId == room.Id && r.Date == date))
                .Select(room => new RoomListDTO()
                {
                    Id = room.Id,
                    Name = room.Name,
                    Type = room.Type,
                    People = room.People,
                    Price = room.Price,

                }).ToList();
        }

                   }
               }

                  
