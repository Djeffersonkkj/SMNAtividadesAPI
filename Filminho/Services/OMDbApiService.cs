using Filminho.DTos;
using Filminho.Services.Interfaces;

namespace Filminho.Services;

public class OMDbApiService : IOMDbApiService
{
    public OMDbApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    private IHttpClientFactory _httpClientFactory;

    public async Task<FilmeDto> ObterFilmePorNome(string nome)
    {
        FilmeDto filme = await _httpClientFactory.CreateClient().GetAsync()
    }

    
}
