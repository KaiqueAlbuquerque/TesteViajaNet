using DominioTesteViajaNet.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraTesteViajaNet.EntityConfig
{
    public class DadosPagamentoConfiguration : EntityTypeConfiguration<DadosPagamento>
    {
        public DadosPagamentoConfiguration()
        {
            HasKey(d => d.DadosPagamentoId);

            Property(d => d.NumeroCartao)
                .IsRequired()
                .HasMaxLength(16);

            Property(p => p.Cvv)
                .IsRequired();

            Property(p => p.NomeImpressoNoCartao)
                .IsRequired();

            Property(p => p.Validade)
                .IsRequired();

            HasRequired(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteId);
        }
    }
}
