using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Workflow.API.Model
{
    public class CadNormaPadrao
    {
        public string Tipo { get; set; } // norma ou padrao
        public string Codigo { get; set; }
        public string Titulo { get; set; }
    }
}
