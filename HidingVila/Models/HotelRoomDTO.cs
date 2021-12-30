using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HotelRoomDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the room name")]
        public string Name { get; set; }
        [Required (ErrorMessage ="Please enter the Occupancy")]
        public int Ocupancy { get; set; }
        [Range(1,3000,ErrorMessage ="the Regular range should be between 1 and 3000")]
        [Required (ErrorMessage ="please enter the regular range")]
        public double RegularRate { get; set; }
        public string Details { get; set; }
        public string SqFt { get; set; }

        public virtual ICollection<HotelImageDTO> HotelImages { get; set; }

        public List<string> ImagesUrl { get; set; }
    }
}
