using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace API.Dtos; 
    public class DetalleProductoDto : BaseDto
    { 
        public int IdProductoFk { get; set; }
        public string ? DetallesAdicionalesProducto { get; set; }

    } 
