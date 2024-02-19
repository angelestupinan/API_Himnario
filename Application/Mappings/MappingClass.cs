using Application.DTOs;
using Application.Features.Himnos.Command.CreateHimnosCommand;
using Application.Features.Himnos.Command.UpdateHimnoCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingClass : Profile
    { 
        public MappingClass()
        {
            CreateMap<CreateHimnoCommand, Himnos>();

            CreateMap<UpdateHimnoCommand, Himnos>();

            CreateMap<Himnos, HimnoDto>();
        }
    }
}
