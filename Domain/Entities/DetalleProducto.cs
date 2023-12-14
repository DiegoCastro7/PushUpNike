using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetalleProducto : BaseEntity
    {
        public int IdProductoFk { get; set; }
        public Producto ? Productos { get; set; }
        public string ? DetallesAdicionalesProducto { get; set; }
    }
}
