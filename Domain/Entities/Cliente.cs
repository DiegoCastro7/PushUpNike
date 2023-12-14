using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string ? Nombres { get; set; }
        public string ? Apellidos { get; set; }
        public string ? Direccion { get; set; }
        public double NroContacto { get; set; }
        public ICollection<ClienteCompra> ? ClienteCompras { get; set; }
        public ICollection<CarritoCompra> ? CarritoCompras { get; set; }
    }
}
