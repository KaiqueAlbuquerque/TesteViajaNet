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
    public class EnderecoServico : BaseServico<Endereco>, IEnderecoServico
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public EnderecoServico(IEnderecoRepositorio enderecoRepositorio)
            : base(enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }
    }
}
