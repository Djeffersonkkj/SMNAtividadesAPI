using AutoMapper;
using InternApi.DTOs;
using InternApi.Enums;
using InternApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
    [ProducesResponseType(401, Description = "O estagiário não foi encontrado.")]
    public ActionResult<EstagiarioDto> ObterEstagiarioPorId( int id )
    {
        var estagiario = _estagiarioService.ObterEstagiarioPorId( id );
        if ( estagiario == null )
            return NotFound();

        return Ok(estagiario);
    }

    [HttpPost]
    [ProducesResponseType(201, Description = "Estagiário cadastrado")]
    public ActionResult CriarEstagiario(EstagiarioCriarDto estagiarioCriarDto)
    {
        _estagiarioService.CriarEstagiario(estagiarioCriarDto);

        return Created();
    }

    [HttpPatch]
    [ProducesResponseType(404, Description = "Usuário não encontrado.")]
    [ProducesResponseType(400, Description = "Senha inválida.")]
    [ProducesResponseType(204, Description = "Sucesso na atualização.")]
    public ActionResult EditarSenha(EstagiarioEditarSenhaDto dto)
    {
        var resultado = _estagiarioService.EditarSenha(dto);

        return resultado switch
        {
            ResultadoAtualizarSenhaEnum.UsuarioNaoEncontrado
                => NotFound(),

            ResultadoAtualizarSenhaEnum.SenhaInvalida
                => BadRequest(),

            ResultadoAtualizarSenhaEnum.Sucesso
                => NoContent(),

            _ => StatusCode(500)
        };
    }
}
