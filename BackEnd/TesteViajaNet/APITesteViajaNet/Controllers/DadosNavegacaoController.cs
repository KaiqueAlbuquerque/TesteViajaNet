using APITesteViajaNet.Servicos;
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
    public class DadosNavegacaoController : ApiController
    {
        private readonly IDadosNavegacaoServico _dadosNavegacaoServico;

        public DadosNavegacaoController(IDadosNavegacaoServico dadosNavegacaoServico)
        {
            _dadosNavegacaoServico = dadosNavegacaoServico;
        }

        [HttpPost]
        public IHttpActionResult Post(DadosNavegacao dadosNavegacao)
        {
            try
            {
                if(
                    dadosNavegacao != null && 
                    dadosNavegacao.Browser != null && 
                    dadosNavegacao.Ip != null && 
                    dadosNavegacao.NomeDaPagina != null
                  )
                    _dadosNavegacaoServico.Add(dadosNavegacao);
                    
                return Ok("true");
            }
            catch
            {
                return BadRequest("false");
            }
        }
    }
}
