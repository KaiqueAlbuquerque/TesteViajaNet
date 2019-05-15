using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboGeraArquivo.Model
{
    public class Venda
    {
        public ClienteExportacao DadosPessoais { get; set; }

        public DadosPagamentoExportacao DadosPagamento { get; set; }

        public EnderecoExportacao Endereco { get; set; }
    }
}
