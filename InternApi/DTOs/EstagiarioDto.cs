using System.ComponentModel.DataAnnotations;

namespace InternApi.DTOs;

public class EstagiarioDto
{

    public int Id { get; set; }

    [Required]
    public string? Nome { get; set; }

    [Required]
    public DateOnly DataNascimento { get; set; }
}
