using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentXpose_Admin.Domain.Entidades
{
    public class Residencia
    {
        public int id { get; set; }
        public string numero { get; set; }
        public string andar { get; set; }
        public Predio predio { get; set; }

        public Residencia() { }
    }
}
