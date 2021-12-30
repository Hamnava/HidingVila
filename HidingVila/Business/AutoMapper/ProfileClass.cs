using AutoMapper;
using DataAccess.Enttities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class ProfileClass : Profile
    {
        public ProfileClass()
        {
            CreateMap<HotelRoomDTO, HotelRoom>().ReverseMap();
            CreateMap<HotelImageDTO, HotelImagesUrl>().ReverseMap();
        }
    }
        
}
