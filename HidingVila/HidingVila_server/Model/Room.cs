using System.Collections.Generic;

namespace HidingVila_server.Model
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public List<Roomprop> roompro { get; set; }
    }
}
