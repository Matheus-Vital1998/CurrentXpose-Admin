﻿
namespace CurrentXpose_Admin.Entidades
{
    public class Morador : BaseModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public Residencia residencia { get; set; }

        public Morador() { }
    }
}