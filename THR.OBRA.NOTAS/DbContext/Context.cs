using Microsoft.EntityFrameworkCore;
using THR.OBRA.NOTAS.Models.Notas;
using THR.OBRA.NOTAS.Models.Usuario;

namespace THR.OBRA.NOTAS.ContextBase
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options){}
        public DbSet<NotasModel> Notas { get; set; }
        public DbSet<ParcelasModel> Parcelas { get; set; }
        public DbSet<ProdutoServicoModel> ProdutosServicos { get;set; }
        public DbSet<TimesModel> Times { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
    }
}
