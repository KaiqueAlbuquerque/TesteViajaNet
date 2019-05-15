using DominioTesteViajaNet.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraTesteViajaNet.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            Property(c => c.Rg)
                .IsRequired()
                .HasMaxLength(9);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(11);

            Property(c => c.Email)
                .IsRequired();

            Property(c => c.Ip)
                .IsRequired();
        }
    }
}
