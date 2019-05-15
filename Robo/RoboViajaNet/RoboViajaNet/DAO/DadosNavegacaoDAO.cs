using RoboGeraArquivo.Model;
using RoboViajaNet.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboGeraArquivo.DAO
{
    public class DadosNavegacaoDAO
    {
        public List<DadosNavegacaoExportacao> GetDadosNavegacao()
        {
            using (TesteViajaNetEntities context = new TesteViajaNetEntities())
            {
                List<DadosNavegacaoExportacao> dadosNavegacoes = new List<DadosNavegacaoExportacao>();

                var dadosNavegacaoRetorno = context.DadosNavegacao.ToList();

                foreach(var d in dadosNavegacaoRetorno)
                {
                    DadosNavegacaoExportacao dadosNavegacao = new DadosNavegacaoExportacao();

                    dadosNavegacao.Ip = d.Ip;
                    dadosNavegacao.NomeDaPagina = d.NomeDaPagina;
                    dadosNavegacao.Browser = d.Browser;
                    dadosNavegacao.DataCadastro = d.DataCadastro.ToString("dd/MM/yyyy");

                    dadosNavegacoes.Add(dadosNavegacao);
                }

                return dadosNavegacoes;
            }
        }
    }
}
