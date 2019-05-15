using RoboGeraArquivo.Model;
using RoboViajaNet.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboGeraArquivo.DAO
{
    public class VendasDAO
    {
        public List<Venda> GetVendas()
        {
            using (TesteViajaNetEntities context = new TesteViajaNetEntities())
            {
                List<Venda> vendas = new List<Venda>();

                var clientes = context.Cliente.ToList();

                foreach(var c in clientes)
                {
                    Venda venda = new Venda();

                    venda.DadosPessoais = new ClienteExportacao();
                    venda.Endereco = new EnderecoExportacao();
                    venda.DadosPagamento = new DadosPagamentoExportacao();

                    venda.DadosPessoais.Nome = c.Nome;
                    venda.DadosPessoais.Cpf = c.Cpf;
                    venda.DadosPessoais.Rg = c.Rg;
                    venda.DadosPessoais.DataNascimento = c.DataNascimento.ToString("dd/MM/yyyy");
                    venda.DadosPessoais.Email = c.Email;
                    venda.DadosPessoais.Telefone = c.Telefone;
                    venda.DadosPessoais.Ip = c.Ip;
                    venda.DadosPessoais.DataCadastro = c.DataCadastro.ToString("dd/MM/yyyy");

                    var endereco = context.Endereco.Where(e => e.ClienteId == c.ClienteId).FirstOrDefault();

                    venda.Endereco.Logradouro = endereco.Logradouro;
                    venda.Endereco.Numero = endereco.Numero;
                    venda.Endereco.Complemento = endereco.Complemento;
                    venda.Endereco.Bairro = endereco.Bairro;
                    venda.Endereco.Cidade = endereco.Cidade;
                    venda.Endereco.Estado = endereco.Estado;
                    venda.Endereco.DataCadastro = endereco.DataCadastro.ToString("dd/MM/yyyy"); 

                    var dadosPagamento = context.DadosPagamento.Where(d => d.ClienteId == c.ClienteId).FirstOrDefault();

                    venda.DadosPagamento.NumeroCartao = dadosPagamento.NumeroCartao;
                    venda.DadosPagamento.Cvv = dadosPagamento.Cvv;
                    venda.DadosPagamento.NomeImpressoNoCartao = dadosPagamento.NomeImpressoNoCartao;
                    venda.DadosPagamento.Validade = dadosPagamento.Validade.ToString("dd/MM/yyyy");
                    venda.DadosPagamento.DataCadastro = dadosPagamento.DataCadastro.ToString("dd/MM/yyyy");

                    vendas.Add(venda);
                }

                return vendas;
            }
        }
    }
}
