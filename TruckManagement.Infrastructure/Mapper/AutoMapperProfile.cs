using AutoMapper;
using TruckManagement.Domain.Models;
using TruckManagement.Infrastructure.Entities;

namespace TruckManagement.Infrastructure.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TrucksEntity, Truck>();
        CreateMap<Truck, TrucksEntity>();
        CreateMap<TruckDto, TrucksEntity>();
        CreateMap<TrucksEntity, TruckDto>();
        CreateMap<TruckDto, Truck>();
        CreateMap<Truck, TruckDto>();
    }
}