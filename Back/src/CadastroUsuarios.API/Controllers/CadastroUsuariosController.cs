using CadastroUsuarios.Persistence;
using CadastroUsuarios.Domain;
using Microsoft.AspNetCore.Mvc;
using Usuarios.Domain.Model;
using CadastroUsuarios.Application.Contratos;

namespace CadastroUsuarios.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CadastroUsuariosController : ControllerBase
{
 
        public ICadastroUsuarioServices _cadastroUsuarioServices { get; }
   
    public CadastroUsuariosController(ICadastroUsuarioServices cadastroUsuarioServices)
    {
            this._cadastroUsuarioServices = cadastroUsuarioServices;
        
        
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var usuario = await _cadastroUsuarioServices.GetAllUsuarioAsync();

            if (usuario == null) return NotFound("Nenhum usuario encontrado!");

            return Ok(usuario);
            
        }
        catch (Exception ex)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuparar usuario:{ex.Message}");
        }
    }

    [HttpGet("{cpf}")]
    public async Task<IActionResult> GetById(string cpf)
    {
        try
        {
            var usuario = await _cadastroUsuarioServices.GetUsuarioByIdAsync(cpf);

            if (usuario == null) return NotFound("Nenhum usuario encontrado!");

            return Ok(usuario);
            
        }
        catch (Exception ex)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuparar usuario:{ex.Message}");
        };
    }


    [HttpPost]

    public async Task<IActionResult> Post(Usuario model){
        try
        {
            var usuario = await _cadastroUsuarioServices.AddUsuarios(model);

            if (usuario == null) return NotFound("Erro ao tentar adicionar usuario!");

            return Ok(usuario);
            
        }
        catch (Exception ex)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar usuario! :{ex.Message}");
        };
    }


    [HttpPut("{CPF}")]

    public async Task<IActionResult> Put(string CPF, Usuario model){
        try
        {
            var usuario = await _cadastroUsuarioServices.UpadateUsuarios(CPF, model);

            if (usuario == null) return NotFound("Erro ao tentar adicionar usuario!");

            return Ok(usuario);
            
        }
        catch (Exception ex)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar usuario! :{ex.Message}");
        };
    }


    [HttpDelete("{CPF}")]
    public async Task<IActionResult> Delete(string CPF){
        try
        {
            if ( await _cadastroUsuarioServices.DeleteUsuarios(CPF))            
                return Ok("Deletado!");
            else
            
                return BadRequest("Usuario não Deletado!"); 
            
            
        }
        catch (Exception ex)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar remover usuario! :{ex.Message}");
        };
    }
}
