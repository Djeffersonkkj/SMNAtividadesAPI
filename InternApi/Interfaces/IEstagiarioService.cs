using InternApi.DTOs;
using InternApi.Enums;

namespace InternApi.Interfaces;

public interface IEstagiarioService
{
    IEnumerable<EstagiarioDto> ObterEstagiarios();
    EstagiarioDto? ObterEstagiarioPorId( int id);
    void CriarEstagiario(EstagiarioCriarDto estagiarioCriarDto);
    ResultadoAtualizarSenhaEnum EditarSenha(EstagiarioEditarSenhaDto dto);
}
