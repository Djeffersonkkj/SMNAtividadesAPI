using Filminho.DTos;
using Filminho.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Filminho.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilminhoController : ControllerBase
{
    public FilminhoController(IOMDbApiService oMDbApiService)
    {
        _oMDbApiService = oMDbApiService;
    }

    private readonly IOMDbApiService _oMDbApiService;

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
        var filme = await _oMDbApiService.ObterFilmePorNomeAsync(nome);

        if (filme is null)
            return NotFound();

        return Ok(filme);
    }

}
