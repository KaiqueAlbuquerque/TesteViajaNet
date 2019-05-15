using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTesteViajaNet.Entidades
{
    public class DadosPagamento
    {
        public int DadosPagamentoId { get; set; }

        public string NumeroCartao { get; set; }

        public string Cvv { get; set; }

        public string NomeImpressoNoCartao { get; set; }

        public DateTime Validade { get; set; }

        public DateTime DataCadastro { get; set; }

        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
