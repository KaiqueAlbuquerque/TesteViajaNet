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
    public class LandingServico : BaseServico<Landing>, ILandingServico
    {
        private readonly ILandingRepositorio _landingRepositorio;

        public LandingServico(ILandingRepositorio landingRepositorio)
            : base(landingRepositorio)
        {
            _landingRepositorio = landingRepositorio;
        }
    }
}
