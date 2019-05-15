using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboGeraArquivo.Model
{
    public class DadosPagamentoExportacao
    {
        public string NumeroCartao { get; set; }

        public string Cvv { get; set; }

        public string NomeImpressoNoCartao { get; set; }

        public string Validade { get; set; }

        public string DataCadastro { get; set; }
    }
}
