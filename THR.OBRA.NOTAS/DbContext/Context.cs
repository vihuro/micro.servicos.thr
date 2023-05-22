using Microsoft.EntityFrameworkCore;

namespace THR.OBRA.NOTAS.ContextBase
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}
