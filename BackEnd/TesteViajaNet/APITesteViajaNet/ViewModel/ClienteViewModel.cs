﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITesteViajaNet.ViewModel
{
    public class ClienteViewModel
    {
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public string DataNascimento { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Ip { get; set; }
    }
}