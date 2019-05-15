using DominioTesteViajaNet.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraTesteViajaNet.EntityConfig
{
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            HasKey(e => e.EnderecoId);

            Property(e => e.Logradouro)
                .IsRequired();

            Property(e => e.Numero)
                .IsRequired();

            Property(e => e.Complemento)
                .IsOptional();

            Property(e => e.Bairro)
                .IsRequired();

            Property(e => e.Cidade)
                .IsRequired();

            Property(e => e.Estado)
                .IsRequired();

            HasRequired(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteId);
        }
    }
}
