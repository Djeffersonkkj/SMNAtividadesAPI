using Asp.Versioning;
using InternApi.DTOs;
using InternApi.Enums;
using InternApi.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace InternApi.Controllers.v2;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class InternApiController : ControllerBase
{
    public InternApiController(IEstagiarioService estagiarioService)
    {
        _estagiarioService = estagiarioService;
    }

    private readonly IEstagiarioService _estagiarioService;

    /// <summary>
    /// Retorna todos os estagiários cadastrados.
    /// </summary>
    /// <returns>Dados dos estagiários</returns>
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

    /// <summary>
    /// Retorna um estagiário pelo id.
    /// </summary>
    /// <param name="id">
    /// Identificador único do estagiário.
    /// </param>
    /// <returns>Dados do estagiario encontrado.</returns>
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

    /// <summary>
    /// Cria um novo estagiário.
    /// </summary>
    /// <param name="estagiarioCriarDto">
    /// Dados necessários para criar um estagiário, como nome, data de nascimento e senha.
    /// </param>
    /// <returns>201 Created</returns>
    [HttpPost]
    [ProducesResponseType(201, Description = "Estagiário cadastrado")]
    public ActionResult CriarEstagiario(EstagiarioCriarDto estagiarioCriarDto)
    {
        _estagiarioService.CriarEstagiario(estagiarioCriarDto);

        return Created();
    }

    /// <summary>
    /// Edita a senha de um estagiário.
    /// </summary>
    /// <param name="dto">
    /// Dados necessários para editar a senha do estagiário. Inclui o id do estagiário, a senha atual para validação e 
    /// a nova senha.
    /// </param>
    /// <returns>204 No Content</returns>
    [HttpPatch]
    [Route("alterarsenha")]
    [ProducesResponseType(404, Description = "Usuário não encontrado.")]
    [ProducesResponseType(400, Description = "Senha inválida.")]
    [ProducesResponseType(204, Description = "Sucesso na atualização.")]
    public ActionResult EditarSenha(EstagiarioEditarSenhaDto dto)
    {
        var resultado = _estagiarioService.EditarSenha(dto);

        return resultado switch
        {
            ResultadoEstagiarioEnum.UsuarioNaoEncontrado
                => NotFound(),

            ResultadoEstagiarioEnum.SenhaInvalida
                => BadRequest(),

            ResultadoEstagiarioEnum.Sucesso
                => NoContent(),

            _ => StatusCode(500)
        };
    }

    /// <summary>
    /// Edita o nome de um estagiário.
    /// </summary>
    /// <param name="dto">
    /// Dados necessários para editar o nome do estagiário. Inclui o id do estagiário e o novo nome.
    /// </param>
    /// <returns>204 No Content</returns>
    [HttpPatch]
    [Route("alterarnome")]
    [ProducesResponseType(404, Description = "Usuário não encontrado.")]
    [ProducesResponseType(204, Description = "Sucesso na atualização.")]
    public ActionResult EditarNome(EstagiarioEditarNomeDto dto)
    {
        var resultado = _estagiarioService.EditarNome(dto);

        return resultado switch
        {
            ResultadoEstagiarioEnum.UsuarioNaoEncontrado
                => NotFound(),

            ResultadoEstagiarioEnum.Sucesso
                => NoContent(),

            _ => StatusCode(500)
        };
    }

    /// <summary>
    /// Edita o nome e a data de nascimento de um estagiário.
    /// </summary>
    /// <param name="dto">
    /// Dados necessários para editar o nome e a data de nascimento do estagiário. Inclui o id do estagiário, o novo nome e a nova data de nascimento.
    /// </param>
    /// <returns>204 No Content</returns>
    [HttpPut]
    [ProducesResponseType(404, Description = "Usuário não encontrado.")]
    [ProducesResponseType(400, Description = "Senha inválida.")]
    [ProducesResponseType(204, Description = "Sucesso na atualização.")]
    public ActionResult EditarEstagiarioCompleto(EstagiarioAtualizarDto dto)
    {
        var resultado = _estagiarioService.EditarEstagiarioCompleto(dto);

         return resultado switch
        {
            ResultadoEstagiarioEnum.UsuarioNaoEncontrado
                => NotFound(),

            ResultadoEstagiarioEnum.SenhaInvalida
                => BadRequest(),

            ResultadoEstagiarioEnum.Sucesso
                => NoContent(),

            _ => StatusCode(500)
        };
    }

    /// <summary>
    /// Deleta um estagiário existente. Para realizar a deleção, é necessário fornecer o id do estagiário e a senha para validação.
    /// </summary>
    /// <param name="id">O id do estagiário a ser deletado.</param>
    /// <param name="senha">A senha do estagiário para validação.</param>
    /// <returns>204 No Content</returns>
    [HttpDelete]
    [Route("deletar")]
    [ProducesResponseType(404, Description = "Usuário não encontrado.")]
    [ProducesResponseType(400, Description = "Senha inválida.")]
    [ProducesResponseType(204, Description = "Estagiario deletado.")]
    public ActionResult Deletar(int id, string senha)
    {
        var resultado = _estagiarioService.Deletar(id, senha);

        return resultado switch
        {
            ResultadoEstagiarioEnum.UsuarioNaoEncontrado
                => NotFound(),

            ResultadoEstagiarioEnum.SenhaInvalida
                => BadRequest(),

            ResultadoEstagiarioEnum.Sucesso
                => NoContent(),

            _ => StatusCode(500)
        };
    }
}
