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
    public class LandingController : ApiController
    {
        private readonly ILandingServico _landingServico;

        public LandingController(ILandingServico landingServico)
        {
            _landingServico = landingServico;
        }

        [HttpPost]
        public IHttpActionResult Post(Landing landing)
        {
            try
            {
                if (
                        landing != null &&
                        landing.Ip != null
                   )
                    _landingServico.Add(landing);

                return Ok("true");
            }
            catch
            {
                return BadRequest("false"); 
            }
        }
    }
}
