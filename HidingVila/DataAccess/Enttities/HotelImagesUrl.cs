using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Enttities
{
    public class HotelImagesUrl
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int RoomId { get; set; }

        [ForeignKey("RoomId")]
        public HotelRoom HotelRoom { get; set; }
    }
}
