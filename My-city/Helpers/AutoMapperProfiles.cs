﻿using AutoMapper;
using Mycity.Dtos;
using Mycity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mycity.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City,CityForListDtio>().ForMember(dest => dest.PhotoUrl, opt =>
              {
                  opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
              });
            CreateMap<City, CityForDetailDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<Photo, PhotoForReturnDto>();
        }
    }
}
