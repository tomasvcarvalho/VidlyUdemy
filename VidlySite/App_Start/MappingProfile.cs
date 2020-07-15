﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlySite.Dtos;
using VidlySite.Models;

namespace VidlySite.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
                
            
            Mapper.CreateMap<CustomerDto, Customer>()
            .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<Movie, MovieDto>();
                
            Mapper.CreateMap<MovieDto, Movie>()
            .ForMember(m => m.Id, opt => opt.Ignore());

        }
    }
}