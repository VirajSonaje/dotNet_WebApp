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
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Reviewer, ReviewerDto>();
       }  
    }
}