using RoboGeraArquivo.Model;
using RoboViajaNet.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboGeraArquivo.DAO
{
    public class LandingDAO
    {
        public List<LandingExportacao> GetLandings()
        {
            using (TesteViajaNetEntities context = new TesteViajaNetEntities())
            {
                List<LandingExportacao> landings = new List<LandingExportacao>();

                var landingsRetorno = context.Landing.ToList();

                foreach(var l in landingsRetorno)
                {
                    LandingExportacao landing = new LandingExportacao();

                    landing.Email = l.Email;
                    landing.Ip = l.Ip;
                    landing.DataCadastro = l.DataCadastro.ToString("dd/MM/yyyy");

                    landings.Add(landing);
                }

                return landings;
            }
        }
    }
}
