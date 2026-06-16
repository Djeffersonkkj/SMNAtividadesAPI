using AutoMapper;
using InternApi.DTOs;
using InternApi.Interfaces;
using Models;

namespace InternApi.Services;

public class EstagiarioService : IEstagiarioService
{
    public EstagiarioService(IEstagiarioRepository estagiarioRepository, IMapper mapper)
    {
        _estagiarioRepository = estagiarioRepository;
        _mapper = mapper;
    }

    private IEstagiarioRepository _estagiarioRepository;
    private IMapper _mapper;

    public IEnumerable<EstagiarioDto> ObterEstagiarios()
    {
        var estagiarios = _estagiarioRepository.ObterEstagiarios();
        var estagiariosDto = _mapper.Map<IEnumerable<EstagiarioDto>>(estagiarios);

        return estagiariosDto;
    }

    public EstagiarioDto? ObterEstagiarioPorId( int id)
    {
        var estagiario = _estagiarioRepository.ObterEstagiarioPorId( id );

        if (estagiario == null)
            return null;
            
        var estagiarioDto = _mapper.Map<EstagiarioDto>(estagiario);

        return estagiarioDto;
    }


}
