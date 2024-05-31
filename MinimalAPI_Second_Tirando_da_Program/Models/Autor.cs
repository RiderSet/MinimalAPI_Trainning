using System.Text.Json.Serialization;

namespace MinimalAPI_Second_Tirando_da_Program.Models;
public class Autor
{

    public Guid CodAu { get; set; }

    //[JsonIgnore]
    public Guid? Codl { get; set; } = null;
    //[JsonIgnore]
    public Guid? CodAs { get; set; } = null;

    public string? Nome { get; set; } = string.Empty;

    public Autor(string nome)
    {
        CodAu = Guid.NewGuid();
        Nome = nome;
    }

    [JsonIgnore]
    public Livro? Livro { get; set; }
    [JsonIgnore]
    public ICollection<Livro>? Livros { get; set; }

    [JsonIgnore]
    public Assunto? Assunto { get; set; }
    [JsonIgnore]
    public ICollection<Assunto>? Assuntos { get; set; }

    public void AddLivro(Livro livro)
    {
        if (livro == null) throw new ArgumentNullException("livro");

        if (livro.CodAu != CodAu)
            throw new InvalidOperationException("Este livro não é deste autor");

        Livros.Add(livro);
    }

    public void AddAssunto(Assunto assunto)
    {
        if (assunto == null)
        {
            ArgumentNullException argumentNullException1 = new("autor");
            ArgumentNullException argumentNullException = argumentNullException1;
            throw argumentNullException;
        }

        if (assunto.CodAu != CodAu)
            throw new InvalidOperationException("Este assunto não é tratado este autor");

        Assuntos.Add(assunto);
    }
}
