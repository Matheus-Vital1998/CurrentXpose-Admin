
namespace CurrentXpose_Admin.Entidades
{
    public class Residencia : BaseModel
    {
        public int id { get; set; }
        public string numero { get; set; }
        public string andar { get; set; }
        public Predio predio { get; set; }

        public Residencia() { }
    }
}
