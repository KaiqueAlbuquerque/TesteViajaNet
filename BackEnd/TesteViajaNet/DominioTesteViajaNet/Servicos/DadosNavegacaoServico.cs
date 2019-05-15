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
    public class DadosNavegacaoServico : BaseServico<DadosNavegacao>, IDadosNavegacaoServico
    {
        private readonly IDadosNavegacaoRepositorio _dadosNavegacaoRepositorio;

        public DadosNavegacaoServico(IDadosNavegacaoRepositorio dadosNavegacaoRepositorio)
            : base(dadosNavegacaoRepositorio)
        {
            _dadosNavegacaoRepositorio = dadosNavegacaoRepositorio;
        }
    }
}
