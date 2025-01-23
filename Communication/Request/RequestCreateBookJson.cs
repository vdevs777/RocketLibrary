using System.ComponentModel.DataAnnotations;

namespace RocketLibrary.Communication.Request;

public class RequestCreateBookJson
{
    [Required(ErrorMessage = "O título é obrigatório.")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "O autor é obrigatório.")]
    public string Autor { get; set; } = string.Empty;

    [Required(ErrorMessage = "O gênero é obrigatório.")]
    public string Genero { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public double Preco { get; set; } 

    public int QuantidadeEstoque { get; set; } 
}
