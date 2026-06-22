
using System.ComponentModel;
using Asp.Versioning;
using InternApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternApi.Controllers.v1;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class EnderecoController : ControllerBase
{
    public EnderecoController(IEnderecoService enderecoService)
    {
        _enderecoService = enderecoService;
    }

    private readonly IEnderecoService _enderecoService;

    /// <summary>
    /// Retorna um endereco a partir do cep
    /// </summary>
    /// <param name="cep">
    /// Cep para localizar o endereco
    /// </param>
    /// <returns>
    /// Endereco do cep
    /// </returns>
    [HttpGet("{cep}")]
    [ProducesResponseType(200, Description = "Sucesso")]
    [ProducesResponseType(400, Description = "Cep inválido.")]
    [ProducesResponseType(404, Description = "Endereco não encontrado")]
    public async Task<IActionResult> Buscar(string cep)
    {
        if(cep.Length != 8)
            return BadRequest();

        var endereco = await _enderecoService.ObterEnderecoPorCepAsync(cep);

        if (endereco is null)
            return NotFound();

        return Ok(endereco);
    }
}
