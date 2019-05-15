using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace APITesteViajaNet.Servicos
{
    public class Comum
    {
        public static string RemoveCaracteresEspeciais(string palavra)
        {
            return Regex.Replace(palavra, "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);
        }
    }
}