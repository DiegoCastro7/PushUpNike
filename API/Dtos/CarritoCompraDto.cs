using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace API.Dtos; 
    public class CarritoCompraDto : BaseDto
    { 
        public int IdClienteFk { get; set; }
        public int IdProductoFk { get; set; }
        public string ? ProductoEnCarrito { get; set; }
        public int CantidadCadaProductoEnCarrito { get; set; }
        public double PrecioTotalCarrito { get; set; }
    } 
