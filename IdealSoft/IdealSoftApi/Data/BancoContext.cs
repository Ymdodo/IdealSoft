using Microsoft.EntityFrameworkCore;

namespace IdealSoftApi.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<Cadastro> Cadastros { get; set; }
    }
}
