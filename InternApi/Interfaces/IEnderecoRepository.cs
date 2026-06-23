using InternApi.Models;

namespace InternApi.Interfaces;

public interface IEnderecoRepository
{
    Task<Endereco?> ObterEnderecoPorCepAsync(string cep);
    Task SalvarEnderecoAsync(Endereco endereco);

}
