using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuarios.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Usuarios.Domain.Model;

namespace CadastroUsuarios.Persistence
{
    public class CadastroUsuarioPersistence : ICadastroUsuarioPersistence
    {
        public DataContext _context { get; }

        public CadastroUsuarioPersistence(DataContext Context)
        {
            this._context = Context;
            
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        } 

         public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) >0;
        }     

        public Task<Sala> GetAllSalasAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario[]> GetAllUsuarioAsync()
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.OrderBy(e => e.CPF);

            return await query.ToArrayAsync();
        }

        public async Task<Sala> GetSalaByIdAsync(int SalaId)
        {
            IQueryable<Sala> query = _context.Salas;

            query = query.OrderBy(e => e).Where(e => e.Id == SalaId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(string CPF)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.OrderBy(e => e).Where(e => e.CPF == CPF);

            return await query.FirstOrDefaultAsync();
        }

       

        
    }
}