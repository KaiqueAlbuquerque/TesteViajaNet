using DominioTesteViajaNet.Entidades;
using DominioTesteViajaNet.Interfaces.Repositorios;
using DominioTesteViajaNet.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTesteViajaNet.Servicos
{
    public class DadosPagamentoServico : BaseServico<DadosPagamento>, IDadosPagamentoServico
    {
        private readonly IDadosPagamentoRepositorio _dadosPagamentoRepositorio;

        public DadosPagamentoServico(IDadosPagamentoRepositorio dadosPagamentoRepositorio)
            : base(dadosPagamentoRepositorio)
        {
            _dadosPagamentoRepositorio = dadosPagamentoRepositorio;
        }
    }
}
