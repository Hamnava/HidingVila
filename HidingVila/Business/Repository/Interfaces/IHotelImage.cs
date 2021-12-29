using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Interfaces
{
    public interface IHotelImage
    {
        Task<int> CreateHotelRoomImage(HotelImageDTO hotelImage);
        Task<int> DeleteHotelRoomImage(int imageId);
        Task<int> DeleteHotelRoomImageByRoomId(int roomId);
        Task<IEnumerable<HotelImageDTO>> GetHotelImageByRoomId(int roomId);
    }
}
