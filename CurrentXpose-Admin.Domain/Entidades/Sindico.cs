using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentXpose_Admin.Domain.Entidades
{
    public class Sindico
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public Condominio condominio { get; set; }
        public Tipo_Relatorio nivel_relatorio { get; set; }

        public Sindico() { }
    }
}
