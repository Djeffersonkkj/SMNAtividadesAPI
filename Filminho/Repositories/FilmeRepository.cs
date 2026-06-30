using Filminho.Data;
using Filminho.Models;
using Filminho.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Filminho.Repositories;

public class FilmeRepository : IFilmeRepository
{
    public FilmeRepository(AppDbContext filmes)
    {
        _dbContext = filmes;
    }

    private readonly AppDbContext _dbContext;

    public async Task<Filme> ObterFilmePorNomeAsync(string nome)
    {
        return await _dbContext.Filme.FindAsync(nome);
    }

    public async Task AdicionarFilmeAsync(Filme filme)
    {
        await _dbContext.Filme.AddAsync(filme);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Filme>> ObterTodosOsFilmesAsync()
    {
        return await _dbContext.Filme.ToListAsync();
    }
}
