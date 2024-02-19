using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuarios.Domain.Model;
using Usuarios.Domain.Model;

namespace CadastroUsuarios.Application.Contratos
{
    public interface ICadastroUsuarioServices
    {
        Task<Usuario> AddUsuarios(Usuario model);
        Task<Usuario> UpadateUsuarios(string CPF, Usuario model);
        Task<bool> DeleteUsuarios(string CPF);

        Task<Usuario> GetUsuarioByIdAsync(string CPF);
        Task<Usuario[]> GetAllUsuarioAsync();

        Task<Sala> GetSalaByIdAsync(int SalaId);
        Task<Sala> GetAllSalasAsync();
    }
}