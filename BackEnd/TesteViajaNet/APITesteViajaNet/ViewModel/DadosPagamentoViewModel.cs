using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITesteViajaNet.ViewModel
{
    public class DadosPagamentoViewModel
    {
        public int DadosPagamentoId { get; set; }

        public string NumeroCartao { get; set; }

        public string Cvv { get; set; }

        public string NomeImpressoNoCartao { get; set; }

        public string Validade { get; set; }
    }
}