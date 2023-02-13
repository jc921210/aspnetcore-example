using Microsoft.EntityFrameworkCore;
using Empresa.Proyecto.Core.Entities;
using Empresa.Proyecto.Infra.Data.Configuration;

namespace Empresa.Proyecto.Infra.Data
{
    public class MyProjectContext : DbContext
    {
        /// <summary>
        /// Constructor para DI
        /// </summary>
        /// <param name="options"></param>
        public MyProjectContext(DbContextOptions<MyProjectContext> options) : base(options)
        {

        }

        public DbSet<SimpleEntity> SimpleEntity => Set<SimpleEntity>();
        public DbSet<ComplexEntity> ComplexEntity => Set<ComplexEntity>();

        protected override void OnModelCreating(ModelBuilder builder)
        {           
            builder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            builder.ApplyConfiguration(new SimpleEntityConfig());
        }
    }
}
