using AutoMapper;
using InternApi.DTOs;
using InternApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace InternApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InternApiController : ControllerBase
{
    public InternApiController(IEstagiarioService estagiarioService)
    {
        _estagiarioService = estagiarioService;
    }

    private readonly IEstagiarioService _estagiarioService;

    [HttpGet]
    [ProducesResponseType<IEnumerable<EstagiarioDto>>(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<EstagiarioDto>> ObterTodosEstagiarios()
    {
        // var estagiarios = _estagiarioService.ListarEstagiarios();
        // var estagiariosDto = new List<EstagiarioDto>();

        // foreach (Estagiario estagiario in estagiarios)
        // {
        //     estagiariosDto.Add(new EstagiarioDto
        //     {
        //         Id = estagiario.Id,
        //         Nome = estagiario.Nome,
        //         DataNascimento = estagiario.DataNascimento
        //     });
        // } // Implementando dto de forma manual
        var estagiariosDto = _estagiarioService.ObterEstagiarios();

        return Ok(estagiariosDto);
    }

    [HttpGet("{id}")]
    [ProducesResponseType<EstagiarioDto>(StatusCodes.Status200OK)]
    [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
    public ActionResult<EstagiarioDto> ObterEstagiarioPorId( int id )
    {
        var estagiario = _estagiarioService.ObterEstagiarioPorId( id );
        if ( estagiario == null )
            return NotFound("Estagiario não encontrado.");

        return Ok(estagiario);
    }
}
