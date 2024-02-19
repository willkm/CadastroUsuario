using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuarios.Domain.Model;

namespace CadastroUsuarios.Domain.Model
{
    public class UsuarioSala
    {
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int SalaID { get; set; }
        public Sala? Sala { get; set; }
    }
}