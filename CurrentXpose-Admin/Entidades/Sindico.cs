using CurrentXpose_Admin.Enums;

namespace CurrentXpose_Admin.Entidades
{
    public class Sindico : BaseModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public Condominio condominio { get; set; }
        public int condominio_id { get; set; }
        public Tipo_Relatorio nivel_relatorio { get; set; }

        public Sindico() { }
    }
}
