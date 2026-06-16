using Models;

namespace InternApi.Interfaces;

public interface IEstagiarioRepository
{
    List<Estagiario> ObterEstagiarios();

    Estagiario? ObterEstagiarioPorId( int id);

    void AdicionarEstagiario(Estagiario estagiario);
}
