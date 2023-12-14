using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
using Api.Repository; 
using Domain.Entities; 
using Domain.Interfaces; 
using Microsoft.EntityFrameworkCore; 
using Persistence.Data; 

namespace Application.Repository 
{ 
    public class CarritoCompraRepository : GenericRepository<CarritoCompra> , ICarritoCompra 
    { 
        public PushUpNikeContext _context { get; set; } 
        public CarritoCompraRepository(PushUpNikeContext context) : base(context) 
        { 
            _context = context; 
        } 
    } 
} 
