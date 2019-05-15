using DominioTesteViajaNet.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITesteViajaNet.ViewModel
{
    public class CompraViewModel
    {
        public ClienteViewModel Cliente { get; set; }

        public DadosPagamentoViewModel DadosPagamento { get; set; }

        public Endereco Endereco { get; set; }
    }
}