using AutoMapper.Configuration.Conventions;

namespace InternApi.Models;

public class Endereco
{
    public int Id { get; set; }
    public required string Cep { get; set; }
    public string? Logradouro { get; set; }
    public string? Bairro { get; set; }
    public string? Localidade { get; set; }
    public string? Uf { get; set; }
    public bool SalvoEmCache { get; set; }
}
