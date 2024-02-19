using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuarios.Domain.Model;
using Usuarios.Domain.Model;

namespace CadastroUsuarios.Persistence
{
    public interface ICadastroUsuarioPersistence
    {
        void Add<T>(T entity) where  T: class;
        void Update<T>(T entity) where  T: class;
        void Delete<T>(T entity) where  T: class;
        void DeleteRange<T>(T[] entity) where  T: class;

        Task<bool> SaveChangesAsync();

        Task<Usuario> GetUsuarioByIdAsync(string CPF);
        Task<Usuario[]> GetAllUsuarioAsync();

        Task<Sala> GetSalaByIdAsync(int SalaId);
        Task<Sala> GetAllSalasAsync();
    }
}