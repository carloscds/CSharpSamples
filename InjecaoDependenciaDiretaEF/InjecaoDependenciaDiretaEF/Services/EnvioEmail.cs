using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InjecaoDependenciaDiretaEF.Services
{
    public class EnvioEmail : IEnvioEmail
    {
        public string Enviar() => "Email Enviado";
    }
}
