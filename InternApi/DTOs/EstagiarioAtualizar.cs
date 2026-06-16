namespace InternApi.DTOs;

public class EstagiarioAtualizar
{
    public int Id { get; set; }

    public required string Nome { get; set; }

    public DateOnly DataNascimento { get; set; }

    public required string SenhaAtual { get; set; }
}
