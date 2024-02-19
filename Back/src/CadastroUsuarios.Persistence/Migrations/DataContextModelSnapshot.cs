﻿// <auto-generated />
using System;
using CadastroUsuarios.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CadastroUsuarios.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CadastroUsuarios.Domain.Model.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("CadastroUsuarios.Domain.Model.UsuarioSala", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("SalaID")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioCPF")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UsuarioId", "SalaID");

                    b.HasIndex("SalaID");

                    b.HasIndex("UsuarioCPF");

                    b.ToTable("UsuariosSalas");
                });

            modelBuilder.Entity("Usuarios.Domain.Model.Usuario", b =>
                {
                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Datnascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CPF");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CadastroUsuarios.Domain.Model.UsuarioSala", b =>
                {
                    b.HasOne("CadastroUsuarios.Domain.Model.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("SalaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Usuarios.Domain.Model.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioCPF");

                    b.Navigation("Sala");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
