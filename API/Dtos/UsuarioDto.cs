using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace API.Dtos; 
    public class UsuarioDto : BaseDto
    { 
        public string Usename { get; set; } = null!;    
        public string Email { get; set; } = null!;
    } 
