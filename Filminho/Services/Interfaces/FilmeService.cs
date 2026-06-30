using Filminho.DTos;

namespace Filminho.Services.Interfaces;

public interface IFilmeService
{
    Task<FilmeDto> ObterFilmePorNomeAsync(string nome);
    Task<bool> SalvarFilmeAsync(FilmeDto filmeDto);
    Task<List<FilmeDto>> ObterTodosOsFilmesAsync();
}
