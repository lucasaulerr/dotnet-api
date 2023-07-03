using AutoMapper;
using FilmsAPI.Data.Dtos;
using FilmsAPI.Models;

namespace FilmsAPI.Profiles;

public class EnderecoProfile : Profile
{
	public EnderecoProfile()
	{
		CreateMap<CreateEnderecoDto, Endereco>();
		CreateMap<UpdateEnderecoDto, Endereco>();
		CreateMap<Endereco, ReadEnderecoDto>();
	}
}