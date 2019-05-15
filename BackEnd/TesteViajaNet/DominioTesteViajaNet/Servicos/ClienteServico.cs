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
    public class ClienteServico : BaseServico<Cliente>, IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
            : base(clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
    }
}
