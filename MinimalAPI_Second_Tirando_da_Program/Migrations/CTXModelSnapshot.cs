﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinimalAPI_Second_Tirando_da_Program.Context;

#nullable disable

namespace MinimalAPI_Second_Tirando_da_Program.Migrations
{
    [DbContext(typeof(CTX))]
    partial class CTXModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MinimalAPI_Second_Tirando_da_Program.Models.Assunto", b =>
                {
                    b.Property<Guid>("CodAs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CodAu")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Codl")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CodAs");

                    b.HasIndex("CodAu");

                    b.HasIndex("Codl");

                    b.ToTable("Assuntos");
                });

            modelBuilder.Entity("MinimalAPI_Second_Tirando_da_Program.Models.Autor", b =>
                {
                    b.Property<Guid>("CodAu")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CodAs")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Codl")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CodAu");

                    b.HasIndex("CodAs");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("MinimalAPI_Second_Tirando_da_Program.Models.Livro", b =>
                {
                    b.Property<Guid>("Codl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnoPublicacao")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid?>("CodAs")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CodAu")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Edicao")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Editora")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Image_Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Codl");

                    b.HasIndex("CodAs");

                    b.HasIndex("CodAu");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("MinimalAPI_Second_Tirando_da_Program.Models.Assunto", b =>
                {
                    b.HasOne("MinimalAPI_Second_Tirando_da_Program.Models.Autor", "Autor")
                        .WithMany("Assuntos")
                        .HasForeignKey("CodAu");

                    b.HasOne("MinimalAPI_Second_Tirando_da_Program.Models.Livro", "Livro")
                        .WithMany("Assuntos")
                        .HasForeignKey("Codl");

                    b.Navigation("Autor");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("MinimalAPI_Second_Tirando_da_Program.Models.Autor", b =>
                {
                    b.HasOne("MinimalAPI_Second_Tirando_da_Program.Models.Assunto", "Assunto")
                        .WithMany("Autores")
                        .HasForeignKey("CodAs");

                    b.HasOne("MinimalAPI_Second_Tirando_da_Program.Models.Livro", "Livro")
                        .WithMany("Autores")
                        .HasForeignKey("CodAu")
                        .IsRequired();

                    b.Navigation("Assunto");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("MinimalAPI_Second_Tirando_da_Program.Models.Livro", b =>
                {
                    b.HasOne("MinimalAPI_Second_Tirando_da_Program.Models.Assunto", "Assunto")
                        .WithMany("Livros")
                        .HasForeignKey("CodAs");

                    b.HasOne("MinimalAPI_Second_Tirando_da_Program.Models.Autor", "Autor")
                        .WithMany("Livros")
                        .HasForeignKey("CodAu");

                    b.Navigation("Assunto");

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("MinimalAPI_Second_Tirando_da_Program.Models.Assunto", b =>
                {
                    b.Navigation("Autores");

                    b.Navigation("Livros");
                });

            modelBuilder.Entity("MinimalAPI_Second_Tirando_da_Program.Models.Autor", b =>
                {
                    b.Navigation("Assuntos");

                    b.Navigation("Livros");
                });

            modelBuilder.Entity("MinimalAPI_Second_Tirando_da_Program.Models.Livro", b =>
                {
                    b.Navigation("Assuntos");

                    b.Navigation("Autores");
                });
#pragma warning restore 612, 618
        }
    }
}