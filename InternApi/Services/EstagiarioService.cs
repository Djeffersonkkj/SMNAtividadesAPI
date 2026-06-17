using AutoMapper;
using InternApi.DTOs;
using InternApi.Enums;
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

    public void CriarEstagiario(EstagiarioCriarDto estagiarioCriarDto)
    {
        var estagiario = _mapper.Map<Estagiario>(estagiarioCriarDto);
        _estagiarioRepository.AdicionarEstagiario(estagiario);
    }

    public ResultadoEstagiarioEnum EditarSenha(EstagiarioEditarSenhaDto dto)
    {
        var estagiario = _estagiarioRepository.ObterEstagiarioPorId( dto.Id );

        if (estagiario is null)
            return ResultadoEstagiarioEnum.UsuarioNaoEncontrado;

        if (estagiario.Senha != dto.SenhaAtual)
            return ResultadoEstagiarioEnum.SenhaInvalida;

        estagiario.EditarSenha( dto.NovaSenha );
        return ResultadoEstagiarioEnum.Sucesso;
    }

    public ResultadoEstagiarioEnum Deletar(int id, string senha)
    {
        var estagiario = _estagiarioRepository.ObterEstagiarioPorId( id );

        if (estagiario is null)
            return ResultadoEstagiarioEnum.UsuarioNaoEncontrado;

        if (estagiario.Senha != senha)
            return ResultadoEstagiarioEnum.SenhaInvalida;

        _estagiarioRepository.Remover(estagiario);
        return ResultadoEstagiarioEnum.Sucesso;
    }


}
