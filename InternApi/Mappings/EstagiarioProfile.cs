using AutoMapper;
using InternApi.DTOs;
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
    }
}
