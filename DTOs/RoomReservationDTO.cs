namespace net_ita_2_checkpoint.DTOs
{
    public class RoomReservationDTO
    {
        public DateTime Date { get; set; }
        public int People { get; set; }
        public Guid RoomId { get; set; }
    }
}