using InternApi.Interfaces;
using Models;

namespace InternApi.Repositories;

public class EstagiarioRepository : IEstagiarioRepository
{
    private List<Estagiario> _estagiarios = [
        new Estagiario("Geremias", new DateOnly(2005, 10, 14), "123456"),
        new Estagiario("Alex, aquele que...", new DateOnly(2000, 1, 12), "123456"),
        new Estagiario("Roberto Carlos", new DateOnly(1800, 12, 1), "123456"),
        new Estagiario("Alexa", new DateOnly(2003, 9, 12), "123456")
    ];

    public List<Estagiario> ObterEstagiarios()
        => _estagiarios;

    public Estagiario? ObterEstagiarioPorId( int id)
        => _estagiarios.FirstOrDefault(estagiario => estagiario.Id == id);
}


