using InternApi.DTOs;

namespace InternApi.Interfaces;

public interface IEnderecoService
{
    Task<EnderecoDto?> ObterEnderecoPorCepAsync(string cep);
}
