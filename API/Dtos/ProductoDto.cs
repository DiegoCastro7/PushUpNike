using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace API.Dtos; 
    public class ProductoDto : BaseDto
    { 
        public string ? Nombre { get; set; }
        public double Precio { get; set; }
        public int IdCategoriaFk { get; set; }
        public string ? Marca { get; set; }
        public string ? UrlImagen { get; set; }
        public int StockDisponible { get; set; }

        public List<CarritoCompraDto> ? CarritoCompras { get; set; }
        public List<CompraDto> ? Compras { get; set; }
        public List<DetalleProductoDto> ? DetalleProductos { get; set; }

    } 
