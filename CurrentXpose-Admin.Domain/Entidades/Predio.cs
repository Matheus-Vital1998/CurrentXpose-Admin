using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentXpose_Admin.Domain.Entidades
{
    public class Predio
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int total_de_andares { get; set; }
        public Condominio condominio { get; set; }

        public Predio() { }
    }
}
