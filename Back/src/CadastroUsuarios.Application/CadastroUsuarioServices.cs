using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuarios.Application.Contratos;
using CadastroUsuarios.Domain.Model;
using CadastroUsuarios.Persistence;
using Usuarios.Domain.Model;

namespace CadastroUsuarios.Application
{
    public class CadastroUsuarioServices : ICadastroUsuarioServices
    {
        public ICadastroUsuarioPersistence _persist { get; }

        public CadastroUsuarioServices(ICadastroUsuarioPersistence persist)
        {
            this._persist = persist;
            
        }

        public async Task<Usuario> AddUsuarios(Usuario model)
        {
            try
            {
                _persist.Add<Usuario>(model);
                if (await _persist.SaveChangesAsync())
                {
                    return await _persist.GetUsuarioByIdAsync(model.CPF);
                }

                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteUsuarios(string CPF)
        {
            try
            {
                var usuario = await _persist.GetUsuarioByIdAsync(CPF);
                if (usuario == null)
                {
                    throw new Exception("Evento para delete não foi encontrado");
                }

                _persist.Delete<Usuario>(usuario);

                return await _persist.SaveChangesAsync();               

                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> UpadateUsuarios(string CPF, Usuario model)
        {
            try
            {
                var usuario = await _persist.GetUsuarioByIdAsync(CPF);
                if (usuario == null)
                {
                    return null;
                }

                _persist.Update(model);

                if (await _persist.SaveChangesAsync())
                {
                    return await _persist.GetUsuarioByIdAsync(model.CPF);
                }

                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public Task<Sala> GetAllSalasAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario[]> GetAllUsuarioAsync()
        {
           try
           {
             var usuarios = await _persist.GetAllUsuarioAsync();

             if(usuarios == null ) return null;

             return usuarios;
           }
           catch (Exception ex)
           {
            
            throw new Exception(ex.Message);
           }
        }

        public Task<Sala> GetSalaByIdAsync(int SalaId)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(string CPF)
        {
            try
           {
             var usuarios = await _persist.GetUsuarioByIdAsync(CPF);

             if(usuarios == null ) return null;

             return usuarios;
           }
           catch (Exception ex)
           {
            
            throw new Exception(ex.Message);
           }
        }

        
    }
}