using System.ComponentModel.DataAnnotations;

namespace InternApi.DTOs;

public class EstagiarioEditarSenhaDto
{
    public int Id { get; set; }


    public required string SenhaAtual { get; set; }

    [MinLength(3)]
    public required string NovaSenha { get; set; }
}
