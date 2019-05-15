using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTesteViajaNet.Entidades
{
    public class DadosNavegacao
    {
        public int DadosNavegacaoId { get; set; }

        public string Ip { get; set; }

        public string NomeDaPagina { get; set; }

        public string Browser { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
