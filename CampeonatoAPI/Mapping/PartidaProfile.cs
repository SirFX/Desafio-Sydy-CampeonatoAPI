using AutoMapper;
using CampeonatoAPI.Domain.Entities;
using CampeonatoAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoAPI.Mapping
{
    public class PartidaProfile : Profile
    {
        public PartidaProfile()
        {
            CreateMap<PartidaEntity, PartidaViewModel>()
                .ForMember(x => x.Times, y => y.MapFrom(src => src.TimeA.Nome + " x " + src.TimeB.Nome))
                .ForMember(x => x.Resultado, y => y.MapFrom(src => src.GolsA + " x " + src.GolsB));
        }
    }
}
