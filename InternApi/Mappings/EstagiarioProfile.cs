using AutoMapper;
using InternApi.DTOs;
using InternApi.Models;
using Models;

namespace InternApi.Mappings;

public class EstagiarioProfile : Profile
{
    public EstagiarioProfile()
    {
        CreateMap<Estagiario, EstagiarioDto>();

        CreateMap<Estagiario, EstagiarioCriarDto>().ReverseMap();

        CreateMap<EstagiarioAtualizarDto, Estagiario>();
        CreateMap<ViaCepDto, EnderecoDto>();
        CreateMap<EnderecoDto, Endereco>().ReverseMap();
    }
}
