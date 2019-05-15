using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTesteViajaNet.Entidades
{
    public class Landing
    {
        public int LandingId { get; set; }

        public string Email { get; set; }

        public string Ip { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
