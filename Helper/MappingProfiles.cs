using AutoMapper;
using dotnet_webapp.Models;
using dotNet_WebApp.Dto;

namespace dotnet_webapp.Helper
{
    public class MappingProfiles : Profile
    {
       public MappingProfiles()
       {
            CreateMap<Pokemon, PokemonDto>();
       }  
    }
}