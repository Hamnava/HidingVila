using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO);
        Task<HotelRoomDTO> UpdateHotelRoom(int roomid, HotelRoomDTO hotelRoomDTO);
        Task<HotelRoomDTO> GetHotelRoom(int roomid);
        Task<IEnumerable<HotelRoomDTO>> GetRooms();
        Task<HotelRoomDTO> ExistRoomName(string roomName, int roomid = 0);
        Task<int> RemoveHotelRoom(int id);
    }
}
