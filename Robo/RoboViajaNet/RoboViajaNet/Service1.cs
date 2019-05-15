using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using RoboGeraArquivo.DAO;
using System.Web.Script.Serialization;
using RoboGeraArquivo.Model;

namespace RoboViajaNet
{
    public partial class Service1 : ServiceBase
    {
        Timer timer1;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer(new TimerCallback(timer1_Tick), null, 15000, 60000);
        }

        protected override void OnStop()
        {
            StreamWriter vWriter = new StreamWriter(@"C:\Users\kaiqu\Desktop\viajanet\Robo\RoboViajaNet\RoboViajaNet\Arquivos\logErro.txt", true);

            vWriter.WriteLine("Servico Parado: " + DateTime.Now.ToString());
            vWriter.Flush();
            vWriter.Close();
        }

        private void timer1_Tick(object sender)
        {
            VendasDAO vendasDao = new VendasDAO();
            List<Venda> vendas = vendasDao.GetVendas();

            LandingDAO landingDAO = new LandingDAO();
            List<LandingExportacao> landings = landingDAO.GetLandings();

            DadosNavegacaoDAO dadosNavegacaoDAO = new DadosNavegacaoDAO();
            List<DadosNavegacaoExportacao> dadosNavegacoes = dadosNavegacaoDAO.GetDadosNavegacao();

            string path = @"c:\Users\kaiqu\Desktop\viajanet\Robo\RoboViajaNet\RoboViajaNet\Arquivos\";

            string jsondataVendas = new JavaScriptSerializer().Serialize(vendas);
            StreamWriter vWriter = new StreamWriter(path + "vendas" + DateTime.Now.ToString("ddMMyyHHmm") + ".json", true);
            vWriter.WriteLine(jsondataVendas);
            vWriter.Flush();
            vWriter.Close();

            string jsondataLanding = new JavaScriptSerializer().Serialize(landings);
            StreamWriter vWriter2 = new StreamWriter(path + "landing" + DateTime.Now.ToString("ddMMyyHHmm") + ".json", true);
            vWriter2.WriteLine(jsondataLanding);
            vWriter2.Flush();
            vWriter2.Close();

            string jsondataDadosNavegacao = new JavaScriptSerializer().Serialize(dadosNavegacoes);
            StreamWriter vWriter3 = new StreamWriter(path + "dadosNavegacao" + DateTime.Now.ToString("ddMMyyHHmm") + ".json", true);
            vWriter3.WriteLine(jsondataDadosNavegacao);
            vWriter3.Flush();
            vWriter3.Close();
        }
    }
}
