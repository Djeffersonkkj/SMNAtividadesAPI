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

    public async Task<FilmeDto> ObterFilmePorNomeAsync(string nome)
    {
        var client = _httpClientFactory.CreateClient("OMDb");
        FilmeDto filme = await client.GetFromJsonAsync<FilmeDto>($"?t={nome}&apikey=f77bb66e&");
        return filme;
    }

    
}
