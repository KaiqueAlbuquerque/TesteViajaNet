using DominioTesteViajaNet.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraTesteViajaNet.EntityConfig
{
    public class DadosNavegacaoConfiguration : EntityTypeConfiguration<DadosNavegacao>
    {
        public DadosNavegacaoConfiguration()
        {
            HasKey(d => d.DadosNavegacaoId);

            Property(d => d.Ip)
                .IsRequired();

            Property(d => d.Browser)
                .IsRequired();

            Property(d => d.NomeDaPagina)
                .IsRequired();
        }
    }
}
