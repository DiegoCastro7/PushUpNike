using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Producto : BaseEntity
    {
        public string ? Nombre { get; set; }
        public double Precio { get; set; }
        public int IdCategoriaFk { get; set; }
        public CategoriaProducto ? CategoriaProductos { get; set; }
        public string ? Marca { get; set; }
        public string ? UrlImagen { get; set; }
        public int StockDisponible { get; set; }
        public ICollection<CarritoCompra> ? CarritoCompras { get; set; }
        public ICollection<Compra> ? Compras { get; set; }
        public ICollection<DetalleProducto> ? DetalleProductos { get; set; }

    }
}
