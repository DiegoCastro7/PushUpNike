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
    public class RefreshTokenRepository : GenericRepository<RefreshToken> , IRefreshToken 
    { 
        public PushUpNikeContext _context { get; set; } 
        public RefreshTokenRepository(PushUpNikeContext context) : base(context) 
        { 
            _context = context; 
        } 
    } 
} 
