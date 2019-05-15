using DominioTesteViajaNet.Entidades;
using InfraTesteViajaNet.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraTesteViajaNet.Contexto
{
    public class Context : DbContext
    {
        public Context()
            : base("TesteViajaNet")
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<DadosNavegacao> DadosNavegacao { get; set; }
        public DbSet<DadosPagamento> DadosPagamento { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Landing> Landing { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new DadosNavegacaoConfiguration());
            modelBuilder.Configurations.Add(new DadosPagamentoConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
            modelBuilder.Configurations.Add(new LandingConfiguration());
        }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if(entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
