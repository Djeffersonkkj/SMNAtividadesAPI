using Filminho.DTos;
using Filminho.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Filminho.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilminhoController : ControllerBase
{
    public FilminhoController(IFilmeService oMDbApiService)
    {
        _filmeService = oMDbApiService;
    }

    private readonly IFilmeService _filmeService;

    /// <summary>
    /// Obter os dados de um filme pelo nome.
    /// </summary>
    /// <param name="nome">
    /// Nome do filme.
    /// </param>
    /// <returns>
    /// Um dto com informações necessárias para o sistema.
    /// </returns>
    [HttpGet("{nome}")]
    [ProducesResponseType(200, Description = "Filme encontrado.")]
    [ProducesResponseType(404, Description = "Filme não encontrado.")]
    public async Task<IActionResult> ObterFilmePorNome(string nome)
    {
        var filme = await _filmeService.ObterFilmePorNomeAsync(nome);

        if (filme is null)
            return NotFound();

        return Ok(filme);
    }

    /// <summary>
    /// Salvar os dados de um filme pelo nome.
    /// </summary>
    /// <param name="nome">
    /// Nome do filme.
    /// </param>
    /// <returns>
    /// Um status code 200 caso o filme seja salvo com sucesso, ou 404 caso o filme não seja encontrado.
    /// </returns>
    [HttpPost("{nome}")]
    [ProducesResponseType(200, Description = "Filme salvo com sucesso.")]
    [ProducesResponseType(404, Description = "Filme não encontrado.")]
    [ProducesResponseType(400, Description = "Filme já existe não banco de dados.")]
    public async Task<IActionResult> SalvarFilmePorNome(string nome)
    {
        var filme = await _filmeService.ObterFilmePorNomeAsync(nome);
        if (filme is null)
            return NotFound();
        
        var resultado = await _filmeService.SalvarFilmeAsync(filme);

        if (resultado == false)
            return BadRequest("Filme já existe no banco de dados.");

        return Ok();
    }

    /// <summary>
    /// Obter todos os filmes assistidos.
    /// </summary>
    /// <returns>
    /// Uma lista de dtos com informações necessárias para o sistema.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(200, Description = "Filmes encontrados.")]
    public async Task<IActionResult> ObterTodosOsAssistidosFilmes()
    {
        var filmes = await _filmeService.ObterTodosOsFilmesAsync();
        return Ok(filmes);
    }

}
