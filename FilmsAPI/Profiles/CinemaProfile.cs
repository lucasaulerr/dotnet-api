using AutoMapper;
using FilmsAPI.Data.Dtos;
using FilmsAPI.Models;

namespace FilmsAPI.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<UpdateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>();
    }
}