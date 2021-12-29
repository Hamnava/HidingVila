using AutoMapper;
using Business.Repository.Interfaces;
using DataAccess.Data;
using DataAccess.Enttities;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class HotelRoomImageServices : IHotelImage
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public HotelRoomImageServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateHotelRoomImage(HotelImageDTO hotelImage)
        {
            var image = _mapper.Map<HotelImageDTO, HotelImagesUrl>(hotelImage);
            await _context.HotelImagesUrls.AddAsync(image);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImage(int imageId)
        {
            var image = await _context.HotelImagesUrls.FindAsync(imageId);
             _context.HotelImagesUrls.Remove(image);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImageByRoomId(int roomId)
        {
            var image = await _context.HotelImagesUrls.Where(ir => ir.RoomId == roomId).ToListAsync();
            _context.HotelImagesUrls.RemoveRange(image);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelImageDTO>> GetHotelImageByRoomId(int roomId)
        {
            return _mapper.Map<IEnumerable<HotelImagesUrl>, IEnumerable<HotelImageDTO>>(
            await _context.HotelImagesUrls.Where(imr => imr.RoomId == roomId).ToListAsync());
        }
    }
}
