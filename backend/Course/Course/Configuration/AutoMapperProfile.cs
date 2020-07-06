using AutoMapper;
using Course.Models;
using Course.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CursusInstantie, CursusInstantieViewModel>();
        }
    }
}