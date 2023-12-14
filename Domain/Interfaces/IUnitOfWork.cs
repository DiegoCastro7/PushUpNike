using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces;

    public interface IUnitOfWork
{
        ICarritoCompra CarritoCompras { get; }
        ICategoriaProducto CategoriaProductos { get; }
        ICliente Clientes { get; }
        IClienteCompra ClienteCompras { get; }
        ICompra Compras { get; }
        IDetalleProducto DetalleProductos { get; }
        IPago Pagos { get; }
        IProducto Productos { get; }
        IRefreshToken RefreshTokens { get; }
        IRol Rols { get; }
        IUsuario Usuarios { get; }
        IUsuarioRoles UsuarioRoless { get; }
        Task<int> SaveAsync();
}
