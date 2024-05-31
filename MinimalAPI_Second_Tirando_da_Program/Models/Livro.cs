using System.Text.Json.Serialization;

namespace MinimalAPI_Second_Tirando_da_Program.Models;
public class Livro
{

    public Guid Codl { get; set; }

    //[JsonIgnore]
    public Guid? CodAu { get; set; } = null;
    //[JsonIgnore]
    public Guid? CodAs { get; set; } = null;

    public Livro(string titulo, string editora, string edicao, string image_Address, string anoPublicacao)
    {
        Codl = Guid.NewGuid();
        Titulo = titulo;
        Editora = editora;
        Edicao = edicao;
        Image_Address = image_Address;
        AnoPublicacao = anoPublicacao;
    }

    public string? Titulo { get; set; } = string.Empty;
    public string? Editora { get; set; } = string.Empty;
    public string? Edicao { get; set; } = string.Empty;
    public string? Image_Address { get; set; } = string.Empty;
    public string AnoPublicacao { get; set; } = string.Empty;

    [JsonIgnore]
    public Autor? Autor { get; set; }
    [JsonIgnore]
    public ICollection<Autor>? Autores { get; set; }

    [JsonIgnore]
    public Assunto? Assunto { get; set; }
    [JsonIgnore]
    public ICollection<Assunto>? Assuntos { get; set; }

    public void AddAutor(Autor autor)
    {
        if (autor == null) throw new ArgumentNullException("autor");

        if (autor.Codl != Codl)
            throw new InvalidOperationException("Este autor não trata deste assunto");

        Autores.Add(autor);
    }

    //-------------------------------
    public void AddAssunto(Assunto assunto)
    {
        if (assunto == null) throw new ArgumentNullException("autor");

        if (assunto.Codl != Codl)
            throw new InvalidOperationException("Este autor não trata deste assunto");

        Assuntos.Add(assunto);
    }
    //-------------------------------
}
