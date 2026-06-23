using AutoMapper;
using InternApi.DTOs;
using InternApi.Interfaces;
using InternApi.Models;

namespace InternApi.Services;

public class EnderecoService : IEnderecoService
{
    public EnderecoService(HttpClient httpClient, IMapper mapper, IEnderecoRepository enderecoRepository)
    {
        _httpClient = httpClient;
        _mapper = mapper;
        _enderecoRepository = enderecoRepository;
    }

    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;
    private readonly IEnderecoRepository _enderecoRepository;

    public async Task<EnderecoDto?> ObterEnderecoPorCepAsync(string cep)
    {
        var cepFormatado = cep.Replace("-", "").Trim();

        var endereco = await _enderecoRepository.ObterEnderecoPorCepAsync(cepFormatado);
        var enderecoDto = _mapper.Map<EnderecoDto>(endereco);

        if (enderecoDto is not null)
           return enderecoDto;

        enderecoDto = await ObterEnderecoPorApiViaCepAsync(cep);

        return enderecoDto;
    }

    private async Task<EnderecoDto?> ObterEnderecoPorApiViaCepAsync(string cep)
    {
        var endereco = await _httpClient.GetFromJsonAsync<ViaCepDto>($"{cep}/json/");
        var enderecoDto = _mapper.Map<EnderecoDto>(endereco);

        if (enderecoDto is null)
            return null;

        enderecoDto.SalvoEmCache = true;

        await _enderecoRepository.SalvarEnderecoAsync(_mapper.Map<Endereco>(enderecoDto));

        return enderecoDto;
    }
}
