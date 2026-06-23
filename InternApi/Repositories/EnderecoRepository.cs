using InternApi.Data;
using InternApi.DTOs;
using InternApi.Interfaces;
using InternApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InternApi.Repositories;

public class EnderecoRepository : IEnderecoRepository
{
    public EnderecoRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    private readonly AppDbContext _appDbContext;

    public async Task<Endereco?> ObterEnderecoPorCepAsync(string cep)
    {
        var endereco = await _appDbContext.Endereco.FirstOrDefaultAsync(e => e.Cep.Replace("-", "").Trim() == cep);

        return endereco;
    }

    public async Task SalvarEnderecoAsync(Endereco endereco)
    {
        _appDbContext.Endereco.Add(endereco);

        await _appDbContext.SaveChangesAsync();
    }
}
