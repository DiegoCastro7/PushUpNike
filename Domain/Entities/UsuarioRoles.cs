using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UsuarioRoles : BaseEntity
    {
        public int UsuarioId { get; set; }
        public Usuario ? Usuarios { get; set; }
        public int RolId { get; set; }
        public Rol ? Roles { get; set; }
    }
}
