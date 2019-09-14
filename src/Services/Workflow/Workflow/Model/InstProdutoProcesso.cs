using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Workflow.API.Model
{
    public class InstProdutoProcesso
    {
        public string Id { get; set; }
        public string Local { get; set; }
        public string Situacao { get; set; } // conforme; nao conforme
        public string NaoConformidade { get; set; }
        public string Comentario { get; set; }
    }
}
