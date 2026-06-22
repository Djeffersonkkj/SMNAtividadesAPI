using AutoMapper;
using InternApi.DTOs;
using InternApi.Interfaces;

namespace InternApi.Services;

public class EnderecoService : IEnderecoService
{
    public EnderecoService(HttpClient httpClient, IMapper mapper)
    {
        _httpClient = httpClient;
        _mapper = mapper;
    }

    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public async Task<EnderecoDto?> ObterEnderecoPorCepAsync(string cep)
    {
        var endereco = await _httpClient.GetFromJsonAsync<ViaCepDto>($"{cep}/json/");
        return _mapper.Map<EnderecoDto>(endereco);
    }
}
