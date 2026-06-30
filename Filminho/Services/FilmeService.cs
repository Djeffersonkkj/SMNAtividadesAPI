using Filminho.DTos;
using Filminho.Mappings;
using Filminho.Models;
using Filminho.Repositories.Interfaces;
using Filminho.Services.Interfaces;

namespace Filminho.Services;

public class FilmeService : IFilmeService
{
    public FilmeService(IHttpClientFactory httpClientFactory, IFilmeRepository filmeRepository)
    {
        _httpClientFactory = httpClientFactory;
        _filmeRepository = filmeRepository;
    }

    private IHttpClientFactory _httpClientFactory;
    private readonly IFilmeRepository _filmeRepository;

    public async Task<FilmeDto> ObterFilmePorNomeAsync(string nome)
    {
        Filme filmeDoBanco = await ObterFilmePorNomeDoBancoAsync(nome);
        if (filmeDoBanco != null)
            return filmeDoBanco.ToFilmeDto();

        var client = _httpClientFactory.CreateClient("OMDb");
        FilmeDto filme = await client.GetFromJsonAsync<FilmeDto>($"?t={nome}&apikey=f77bb66e&");
        return filme;
    }

    public async Task<List<FilmeDto>> ObterTodosOsFilmesAsync()
    {
        List<Filme> filmesDoBanco = await _filmeRepository.ObterTodosOsFilmesAsync();
        return filmesDoBanco.Select(filme => filme.ToFilmeDto()).ToList();
    }

    public async Task<bool> SalvarFilmeAsync(FilmeDto filmeDto)
    {
        Filme filmeDoBanco = await ObterFilmePorNomeDoBancoAsync(filmeDto.Title);
        if (filmeDoBanco != null)
            return false;

        Filme filme = filmeDto.ToFilme();
        await _filmeRepository.AdicionarFilmeAsync(filme);
        return true;
    }

    private async Task<Filme> ObterFilmePorNomeDoBancoAsync(string nome)
    {
        return await _filmeRepository.ObterFilmePorNomeAsync(nome);
    }
}
