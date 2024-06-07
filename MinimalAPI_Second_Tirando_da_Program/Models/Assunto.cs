using System.Text.Json.Serialization;

namespace MinimalAPI_Second_Tirando_da_Program.Models;
public class Assunto
{

    [JsonIgnore]
    public Guid CodAs { get; set; }

    //[JsonIgnore]
    public Guid? Codl { get; set; } = null;
    //[JsonIgnore]
    public Guid? CodAu { get; set; } = null;

    public string? Descricao { get; set; } = string.Empty;

    public Assunto(string descricao)
    {
        CodAs = Guid.NewGuid();
        Descricao = descricao;
    }

    [JsonIgnore]
    public Livro? Livro { get; set; }
    [JsonIgnore]
    public ICollection<Livro>? Livros { get; set; }

    [JsonIgnore]
    public Autor? Autor { get; set; }
    [JsonIgnore]
    public ICollection<Autor>? Autores { get; set; }

    public void AddLivros(Livro livro)
    {
        if (livro == null) throw new ArgumentNullException("livro");

        if (livro.CodAs != CodAs)
            throw new InvalidOperationException("O livro não cita a este assunto");

        Livros.Add(livro);
    }
    //-------------------------------

    public void AddAutor(Autor autor)
    {
        if (autor == null) throw new ArgumentNullException(nameof(autor));

        if (autor.CodAs != CodAs)
            throw new InvalidOperationException("Este autor não trata deste assunto");

        Autores.Add(autor);
    }
    //-------------------------------
}

