using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Workflow.API.Model
{
    public class InstProcessoProduto
    {
        public string Tipo { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public string Situacao { get; set; } // conforme; nao conforme
        public string NaoConformidade { get; set; }
        public string Comentario { get; set; }
    }
}
