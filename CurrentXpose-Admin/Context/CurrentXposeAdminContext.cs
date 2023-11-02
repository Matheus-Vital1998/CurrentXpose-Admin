using CurrentXpose_Admin.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CurrentXpose_Admin.Context
{
    public partial class CurrentXposeAdminContext : DbContext
    {
        public virtual DbSet<Condominio> Condominio { get; set; }
        public virtual DbSet<Morador> Morador { get; set; }
        public virtual DbSet<Predio> Predio { get; set; }
        public virtual DbSet<Residencia> Residencia { get; set; }
        public virtual DbSet<Sindico> Sindico { get; set; }

        public CurrentXposeAdminContext()
        {
        }

        public CurrentXposeAdminContext(DbContextOptions<CurrentXposeAdminContext> options) : base(options)
        {
        }
    }
}
