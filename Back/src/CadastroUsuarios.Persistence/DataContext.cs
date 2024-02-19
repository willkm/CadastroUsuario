using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuarios.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Usuarios.Domain.Model;

namespace CadastroUsuarios.Persistence
{
    public class DataContext : DbContext
    {
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

     protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server with connection string from app settings
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Sala> Salas { get; set; }

        public DbSet<UsuarioSala> UsuariosSalas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioSala>().HasKey(US => new {US.UsuarioId, US.SalaID});
        }
    }
}