using AutoMapper;
using FilmsAPI.Data.Dtos;
using FilmsAPI.Models;

namespace FilmsAPI.Profiles;

public class FilmeProfile : Profile
{
	public FilmeProfile()
	{
        // CreateMap<ObjectA, ObjectB>(); 
        // Cria a possibilidade de conversão de um objecto A para um objeto B.
        
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>();
    }
}
