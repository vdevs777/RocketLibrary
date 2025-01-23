using Microsoft.AspNetCore.Mvc;
using RocketLibrary.Models;
using RocketLibrary.Communication.Request;

namespace RocketLibrary.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private static List<Book> Livros = [];

    [HttpPost]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestCreateBookJson request)
    {
        var book = new Book{
            Id = Guid.NewGuid().ToString(),
            Autor = request.Autor,
            Genero = request.Genero,
            Preco = request.Preco,
            QuantidadeEstoque = request.QuantidadeEstoque,
            Titulo = request.Titulo,
        };

        Livros.Add(book);

        return Ok(book);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        return Ok(Livros);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] string id)
    {
        var livroPraDeletar = Livros.FirstOrDefault(book => book.Id == id);

        if (livroPraDeletar == null)
        {
            ModelState.AddModelError("Id", "Este livro não existe!");
            return ValidationProblem(ModelState);
        }
        else
        {
            Livros.Remove(livroPraDeletar);
            return NoContent();
        }
    }

    [HttpPut]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [Route("{id}")]
    public IActionResult Update(string id, [FromBody] RequestCreateBookJson request)
    {
        var book = Livros.FirstOrDefault(x => x.Id == id);
        if (book == null)
        {
            ModelState.AddModelError("Id", "Este livro não existe!");
            return ValidationProblem(ModelState);
        }
        // Atualizando os dados do livro
        book.Titulo = request.Titulo;
        book.Autor = request.Autor;
        book.Genero = request.Genero;
        book.Preco = request.Preco;
        book.QuantidadeEstoque = request.QuantidadeEstoque;

        return Ok(book);
    }

}  
