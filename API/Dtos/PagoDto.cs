using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace API.Dtos; 
    public class PagoDto : BaseDto
    { 
        public string ? Nombre { get; set; }

        public List<ClienteCompraDto> ? ClienteCompras { get; set; }

    } 
