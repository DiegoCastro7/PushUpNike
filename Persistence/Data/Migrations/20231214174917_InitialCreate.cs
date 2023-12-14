using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoriaProducto",
                columns: table => new
                {
                    IdCategoriaProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProducto", x => x.IdCategoriaProducto);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombres = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellidos = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NroContacto = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.IdPago);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreRol = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_Usuario);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<double>(type: "double", nullable: false),
                    IdCategoriaFk = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UrlImagen = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StockDisponible = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Producto_CategoriaProducto_IdCategoriaFk",
                        column: x => x.IdCategoriaFk,
                        principalTable: "CategoriaProducto",
                        principalColumn: "IdCategoriaProducto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioRoless",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRoless", x => new { x.UsuarioId, x.RolId });
                    table.ForeignKey(
                        name: "FK_UsuarioRoless_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRoless_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CarritoCompra",
                columns: table => new
                {
                    IdCarritoCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdClienteFk = table.Column<int>(type: "int", nullable: false),
                    IdProductoFk = table.Column<int>(type: "int", nullable: false),
                    ProductoEnCarrito = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CantidadCadaProductoEnCarrito = table.Column<int>(type: "int", nullable: false),
                    PrecioTotalCarrito = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoCompra", x => x.IdCarritoCompra);
                    table.ForeignKey(
                        name: "FK_CarritoCompra_Cliente_IdClienteFk",
                        column: x => x.IdClienteFk,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoCompra_Producto_IdProductoFk",
                        column: x => x.IdProductoFk,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProductoFk = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ValorUnitUSD = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compra_Producto_IdProductoFk",
                        column: x => x.IdProductoFk,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalleProducto",
                columns: table => new
                {
                    IdDetalleProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProductoFk = table.Column<int>(type: "int", nullable: false),
                    DetallesAdicionalesProducto = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleProducto", x => x.IdDetalleProducto);
                    table.ForeignKey(
                        name: "FK_DetalleProducto_Producto_IdProductoFk",
                        column: x => x.IdProductoFk,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClienteCompra",
                columns: table => new
                {
                    IdClienteCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdClienteFk = table.Column<int>(type: "int", nullable: false),
                    IdCompraFk = table.Column<int>(type: "int", nullable: false),
                    FechaTransaccion = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ValorTotalTransaccion = table.Column<double>(type: "double", nullable: false),
                    IdMetodoPagoFk = table.Column<int>(type: "int", nullable: false),
                    DireccionCliente = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteCompra", x => x.IdClienteCompra);
                    table.ForeignKey(
                        name: "FK_ClienteCompra_Cliente_IdClienteFk",
                        column: x => x.IdClienteFk,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteCompra_Compra_IdCompraFk",
                        column: x => x.IdCompraFk,
                        principalTable: "Compra",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteCompra_Pago_IdMetodoPagoFk",
                        column: x => x.IdMetodoPagoFk,
                        principalTable: "Pago",
                        principalColumn: "IdPago",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CategoriaProducto",
                columns: new[] { "IdCategoriaProducto", "Nombre" },
                values: new object[,]
                {
                    { 1, "Jackets" },
                    { 2, "T-Shirts" },
                    { 3, "Pants" }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "IdCliente", "Apellidos", "Direccion", "Nombres", "NroContacto" },
                values: new object[,]
                {
                    { 1, "Castro Torres", "Calle 15, Bucaramanga", "Diego Fernando", 3115411220.0 },
                    { 2, "Aristizabal", "Carrera 23, Piedecuesta", "Jennifer", 3115422110.0 },
                    { 3, "Castro Torres", "Calle 25, Giron", "Alexandra", 3118473642.0 }
                });

            migrationBuilder.InsertData(
                table: "Pago",
                columns: new[] { "IdPago", "Nombre" },
                values: new object[,]
                {
                    { 1, "Tarjeta de Crédito" },
                    { 2, "Transferencia Bancaria" },
                    { 3, "PayPal" },
                    { 4, "Efectivo" },
                    { 5, "Cheque" },
                    { 6, "Tarjeta de Débito" }
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "IdRol", "NombreRol" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Gerente" },
                    { 3, "Empleado" },
                    { 4, "Persona" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id_Usuario", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "fercho11422@gmail.com", "123456", "Diego Castro" },
                    { 2, "jennifer@gmail.com", "1234567", "Jennifer Aristizabal" },
                    { 3, "alexandra@gmail.com", "1234568", "Alexandra Castro" }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "IdProducto", "IdCategoriaFk", "Marca", "Nombre", "Precio", "StockDisponible", "UrlImagen" },
                values: new object[,]
                {
                    { 1, 1, "Nike", "Abrigo 01", 1000.0, 10, "aa" },
                    { 2, 2, "Nike", "Camiseta 01", 500.0, 100, "aa" },
                    { 3, 3, "Nike", "Pantalon 01", 1200.0, 30, "aa" }
                });

            migrationBuilder.InsertData(
                table: "CarritoCompra",
                columns: new[] { "IdCarritoCompra", "CantidadCadaProductoEnCarrito", "IdClienteFk", "IdProductoFk", "PrecioTotalCarrito", "ProductoEnCarrito" },
                values: new object[,]
                {
                    { 1, 2, 1, 1, 20.5, "Producto 1" },
                    { 2, 1, 1, 3, 15.75, "Producto 2" },
                    { 3, 3, 2, 2, 30.0, "Producto 3" },
                    { 4, 1, 3, 1, 10.0, "Producto 4" },
                    { 5, 2, 2, 3, 25.5, "Producto 5" }
                });

            migrationBuilder.InsertData(
                table: "Compra",
                columns: new[] { "IdCompra", "Cantidad", "IdProductoFk", "ValorUnitUSD" },
                values: new object[,]
                {
                    { 1, 3, 1, 20.0 },
                    { 2, 2, 2, 15.5 },
                    { 3, 1, 3, 30.0 }
                });

            migrationBuilder.InsertData(
                table: "DetalleProducto",
                columns: new[] { "IdDetalleProducto", "DetallesAdicionalesProducto", "IdProductoFk" },
                values: new object[,]
                {
                    { 1, "Detalles adicionales para Producto 1", 1 },
                    { 2, "Detalles adicionales para Producto 2", 2 },
                    { 3, "Detalles adicionales para Producto 3", 3 }
                });

            migrationBuilder.InsertData(
                table: "ClienteCompra",
                columns: new[] { "IdClienteCompra", "DireccionCliente", "FechaTransaccion", "IdClienteFk", "IdCompraFk", "IdMetodoPagoFk", "ValorTotalTransaccion" },
                values: new object[,]
                {
                    { 1, "Calle A, Ciudad", new DateTime(2023, 12, 14, 12, 49, 17, 348, DateTimeKind.Local).AddTicks(323), 1, 1, 1, 50.0 },
                    { 2, "Calle B, Ciudad", new DateTime(2023, 12, 14, 12, 49, 17, 348, DateTimeKind.Local).AddTicks(339), 2, 2, 2, 75.0 },
                    { 3, "Calle C, Ciudad", new DateTime(2023, 12, 14, 12, 49, 17, 348, DateTimeKind.Local).AddTicks(340), 3, 3, 1, 100.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoCompra_IdClienteFk",
                table: "CarritoCompra",
                column: "IdClienteFk");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoCompra_IdProductoFk",
                table: "CarritoCompra",
                column: "IdProductoFk");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteCompra_IdClienteFk",
                table: "ClienteCompra",
                column: "IdClienteFk");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteCompra_IdCompraFk",
                table: "ClienteCompra",
                column: "IdCompraFk");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteCompra_IdMetodoPagoFk",
                table: "ClienteCompra",
                column: "IdMetodoPagoFk");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdProductoFk",
                table: "Compra",
                column: "IdProductoFk");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProducto_IdProductoFk",
                table: "DetalleProducto",
                column: "IdProductoFk");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdCategoriaFk",
                table: "Producto",
                column: "IdCategoriaFk");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UsuarioId",
                table: "RefreshToken",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Username",
                table: "Usuario",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoless_RolId",
                table: "UsuarioRoless",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoCompra");

            migrationBuilder.DropTable(
                name: "ClienteCompra");

            migrationBuilder.DropTable(
                name: "DetalleProducto");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "UsuarioRoless");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "CategoriaProducto");
        }
    }
}
