namespace Models;

public class Estagiario
{
    public Estagiario(string nome, DateOnly dataNascimento, string senha)
    {
        _estagiariosCadastrados ++;
        Id = _estagiariosCadastrados;

        Nome = nome;
        DataNascimento = dataNascimento;
        Senha = senha;
    }

    private static int _estagiariosCadastrados;


    public string Senha { get; private set; }
    public int Id { get; }
    public string? Nome { get; private set; }
    public DateOnly DataNascimento { get; private set; }

    public void EditarSenha(string novaSenha)
        => Senha = novaSenha;

    public void AtualizarTodosCampos(string nome, DateOnly dataNascimento)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
    }
    


}
