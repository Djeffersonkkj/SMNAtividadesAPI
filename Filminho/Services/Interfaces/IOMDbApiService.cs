using Filminho.DTos;

namespace Filminho.Services.Interfaces;

public interface IOMDbApiService
{
    Task<FilmeDto> ObterFilmePorNomeAsync(string nome);
}
