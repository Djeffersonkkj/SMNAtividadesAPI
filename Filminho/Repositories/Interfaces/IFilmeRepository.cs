using Filminho.Models;

namespace Filminho.Repositories.Interfaces;

public interface IFilmeRepository
{
    Task<Filme> ObterFilmePorNomeAsync(string nome);
    Task AdicionarFilmeAsync(Filme filme);
    Task<List<Filme>> ObterTodosOsFilmesAsync();

}
