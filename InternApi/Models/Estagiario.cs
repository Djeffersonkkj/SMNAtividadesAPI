namespace Models;

public class Estagiario
{
    public Estagiario(string nome, DateOnly dataNascimento, string senha)
    {
        _estagiariosCadastrados ++;
        Id = _estagiariosCadastrados;

        Nome = nome;
        DataNascimento = dataNascimento;
        _senha = senha;
    }

    private static int _estagiariosCadastrados;


    public string _senha;
    public int Id { get; }
    public string? Nome { get; }
    public DateOnly DataNascimento { get; }


}
