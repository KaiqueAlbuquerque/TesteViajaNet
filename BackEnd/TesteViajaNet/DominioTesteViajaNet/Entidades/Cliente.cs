using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTesteViajaNet.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Ip { get; set; }

        public virtual IEnumerable<Endereco> Enderecos { get; set; }

        public virtual IEnumerable<DadosPagamento> DadosPagamentos { get; set; }
    }
}
