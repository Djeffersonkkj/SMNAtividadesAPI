namespace InternApi.DTOs;

public class EstagiarioAtualizarDto
{
    public int Id { get; set; }

    public required string Nome { get; set; }

    public DateOnly DataNascimento { get; set; }

    public required string SenhaAtual { get; set; }
}
