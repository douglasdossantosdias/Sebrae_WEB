using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sebrae_WEB.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string NomeUsuario { get; set; }

        public string SenhaUsuario { get; set; }

        public string Frase { get; set; }
    }
}