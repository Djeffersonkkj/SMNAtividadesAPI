using InternApi.DTOs;

namespace InternApi.Interfaces;

public interface IEstagiarioService
{
    IEnumerable<EstagiarioDto> ObterEstagiarios();
    EstagiarioDto? ObterEstagiarioPorId( int id);
}
