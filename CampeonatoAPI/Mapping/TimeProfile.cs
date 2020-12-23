using AutoMapper;
using CampeonatoAPI.Domain.Entities;
using CampeonatoAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoAPI.Mapping
{
    public class TimeProfile : Profile
    {
        public TimeProfile()
        {
            CreateMap<TimeEntity, TimeViewModel>();
        }
    }
}
