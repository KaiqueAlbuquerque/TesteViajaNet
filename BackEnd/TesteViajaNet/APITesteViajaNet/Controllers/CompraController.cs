using APITesteViajaNet.Servicos;
using APITesteViajaNet.ViewModel;
using AutoMapper;
using DominioTesteViajaNet.Entidades;
using DominioTesteViajaNet.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APITesteViajaNet.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CompraController : ApiController
    {
        private readonly IEnderecoServico _enderecoServico;
        private readonly IClienteServico _clienteServico;
        private readonly IDadosPagamentoServico _dadosPagamentoServico;

        public CompraController(
                                    IEnderecoServico enderecoServico,
                                    IClienteServico clienteServico,
                                    IDadosPagamentoServico dadosPagamentoServico
                               )
        {
            _enderecoServico = enderecoServico;
            _clienteServico = clienteServico;
            _dadosPagamentoServico = dadosPagamentoServico;
        }

        [HttpPost]
        public IHttpActionResult Post(CompraViewModel compraViewModel)
        {
            try
            {
                if(
                    compraViewModel != null && 
                    compraViewModel.Cliente != null && compraViewModel.Cliente.Ip != null &&
                    compraViewModel.DadosPagamento != null && 
                    compraViewModel.Endereco != null
                  )
                {
                    compraViewModel.Cliente.Cpf = Comum.RemoveCaracteresEspeciais(compraViewModel.Cliente.Cpf).Trim();
                    compraViewModel.Cliente.Rg = Comum.RemoveCaracteresEspeciais(compraViewModel.Cliente.Rg).Trim();
                    compraViewModel.Cliente.Telefone = Comum.RemoveCaracteresEspeciais(compraViewModel.Cliente.Telefone).Trim();
                    var cliente = Mapper.Map<ClienteViewModel, Cliente>(compraViewModel.Cliente);
                    _clienteServico.Add(cliente);

                    compraViewModel.DadosPagamento.NumeroCartao = Comum.RemoveCaracteresEspeciais(compraViewModel.DadosPagamento.NumeroCartao).Trim();
                    compraViewModel.DadosPagamento.Cvv = Comum.RemoveCaracteresEspeciais(compraViewModel.DadosPagamento.Cvv).Trim();
                    compraViewModel.DadosPagamento.Validade = "31/" + compraViewModel.DadosPagamento.Validade;
                    var dadosPagamento = Mapper.Map<DadosPagamentoViewModel, DadosPagamento>(compraViewModel.DadosPagamento);
                    dadosPagamento.ClienteId = cliente.ClienteId;
                    _dadosPagamentoServico.Add(dadosPagamento);

                    compraViewModel.Endereco.ClienteId = cliente.ClienteId;
                    _enderecoServico.Add(compraViewModel.Endereco);
                }
                
                return Ok("true");
            }
            catch
            {
                return BadRequest("false");
            }
        }
    }
}
