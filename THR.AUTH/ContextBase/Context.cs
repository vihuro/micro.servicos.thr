using Microsoft.EntityFrameworkCore;
using THR.AUTH.Models;

namespace THR.AUTH.DBContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions <Context> options) : base(options){}
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<ClaimsModel> Claims { get; set; }
        public DbSet<ClaimsForUserModel> ClaimsForUser { get; set; }

    }
}
