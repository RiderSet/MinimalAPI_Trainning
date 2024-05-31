using Microsoft.EntityFrameworkCore;
using MinimalAPI_Second_Tirando_da_Program.Models;

namespace MinimalAPI_Second_Tirando_da_Program.Context
{
    public class CTX : DbContext
    {
        public CTX(DbContextOptions<CTX> options) : base(options)
        {

        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Livro>().HasKey(c => c.Codl);
            modelBuilder.Entity<Livro>().Property(c => c.Titulo).HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Livro>().Property(c => c.Editora).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Livro>().Property(c => c.Edicao).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Livro>().Property(c => c.Image_Address).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Livro>().Property(c => c.AnoPublicacao).HasMaxLength(10).IsRequired();
           // modelBuilder.Entity<Livro>().HasKey(x => new { x.Codl, x.CodAs });
            modelBuilder.Entity<Livro>()
                .HasOne(x => x.Assunto)
                .WithMany(e => e.Livros)
                .HasForeignKey(t => t.CodAs)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //modelBuilder.Entity<Livro>().HasKey(x => new { x.Codl, x.CodAu });
            modelBuilder.Entity<Livro>()
                .HasOne(x => x.Autor)
                .WithMany(e => e.Livros)
                .HasForeignKey(t => t.CodAu)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Assunto>().HasKey(c => c.CodAs);
            modelBuilder.Entity<Assunto>().Property(c => c.Descricao).HasMaxLength(200).IsRequired();
            //modelBuilder.Entity<Assunto>().HasKey(x => new { x.CodAs, x.Codl });
            modelBuilder.Entity<Assunto>()
                .HasOne(x => x.Livro)
                .WithMany(e => e.Assuntos)
                .HasForeignKey(t => t.Codl)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //modelBuilder.Entity<Assunto>().HasKey(x => new { x.CodAs, x.CodAu });
            modelBuilder.Entity<Assunto>()
                .HasOne(x => x.Autor)
                .WithMany(e => e.Assuntos)
                .HasForeignKey(t => t.CodAu)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Autor>().HasKey(c => c.CodAu);
            modelBuilder.Entity<Autor>().Property(c => c.Nome).HasMaxLength(100).IsRequired();
          //modelBuilder.Entity<Autor>().HasKey(x => new { x.CodAu, x.Codl });
            modelBuilder.Entity<Autor>()
                .HasOne(x => x.Livro)
                .WithMany(e => e.Autores)
                .HasForeignKey(t => t.CodAu)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //modelBuilder.Entity<Autor>().HasKey(x => new { x.CodAu, x.CodAs });
            modelBuilder.Entity<Autor>()
                .HasOne(x => x.Assunto)
                .WithMany(e => e.Autores)
                .HasForeignKey(t => t.CodAs)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
