using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace API.Dtos; 
    public class CategoriaProductoDto : BaseDto
    { 
        public string ? Nombre { get; set; }

        public List<ProductoDto> ? Productos { get; set; }
    } 
