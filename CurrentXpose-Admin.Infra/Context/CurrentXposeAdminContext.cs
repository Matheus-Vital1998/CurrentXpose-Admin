using CurrentXpose_Admin.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentXpose_Admin.Infra.Context
{
    public partial class CurrentXposeAdminContext : DbContext
    {
        public virtual DbSet<Condominio> Condominio { get; set; }
        public virtual DbSet<Leitura> Leitura { get; set; }
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
