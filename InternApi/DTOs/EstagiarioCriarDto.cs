using System.ComponentModel.DataAnnotations;

namespace InternApi.DTOs;

public class EstagiarioCriarDto
{
    [Required]
    public string? Nome { get; set; }

    [Required]
    public string? Senha { get; set; }
    
    [Required]
    public DateOnly DataNascimento { get; set; }

}
