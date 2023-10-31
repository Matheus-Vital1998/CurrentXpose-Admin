
namespace CurrentXpose_Admin.Entidades
{
    public class Predio : BaseModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int total_de_andares { get; set; }
        public Condominio condominio { get; set; }

        public Predio() { }
    }
}
