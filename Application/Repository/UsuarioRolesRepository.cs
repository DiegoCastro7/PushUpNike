using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
using Api.Repository; 
using Domain.Entities; 
using Domain.Interfaces; 
using Microsoft.EntityFrameworkCore; 
using Persistence.Data; 

namespace Application.Repository 
{ 
    public class UsuarioRolesRepository : GenericRepository<UsuarioRoles> , IUsuarioRoles 
    { 
        public PushUpNikeContext _context { get; set; } 
        public UsuarioRolesRepository(PushUpNikeContext context) : base(context) 
        { 
            _context = context; 
        } 
    } 
} 
