using DominioTesteViajaNet.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraTesteViajaNet.EntityConfig
{
    public class LandingConfiguration : EntityTypeConfiguration<Landing>
    {
        public LandingConfiguration()
        {
            HasKey(l => l.LandingId);

            Property(l => l.Email)
                .IsRequired();

            Property(l => l.Ip)
                .IsRequired();
        }
    }
}
