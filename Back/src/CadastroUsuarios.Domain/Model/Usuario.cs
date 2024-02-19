using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Usuarios.Domain.Model
{
    public class Usuario
    {
        [Key]
        public string CPF { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public DateTime Datnascimento { get; set; }
        public string Endereco { get; set; } = string.Empty;   
        public string Email { get; set; } = string.Empty;             
        public string ImagemURL { get; set; } = string.Empty;
    }
}